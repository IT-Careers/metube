using MeTube.Data.Models.Channels;
using MeTube.Data.Models.Playlists;
using MeTube.Data.Repository.Channels;
using MeTube.Data.Repository.Playlists;
using MeTube.Data.Repository.Videos;
using MeTube.Service.Mappings.Playlists;
using MeTube.Service.Models.Playlist;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service.Playlists;

public class PlaylistService : IPlaylistService
{
    private readonly PlaylistRepository _playlistRepository;

    private readonly IVideoRepository _videoRepository;

    private readonly ChannelRepository _channelRepository;

    public PlaylistService(PlaylistRepository playlistRepository, IVideoRepository videoRepository, ChannelRepository channelRepository)
    {
        this._playlistRepository = playlistRepository;
        this._videoRepository = videoRepository;
        this._channelRepository = channelRepository;
    }

    public async Task<PlaylistDto> GetByIdAsync(string id)
    {
        return (await this.GetByIdInternalAsync(id)).ToPlaylistDto();
    }

    public IQueryable<PlaylistDto> GetAll()
    {
        return this._playlistRepository.GetAllAsNoTracking()
            .Select(playlist => playlist.ToPlaylistDto(true, true, true, true));
    }

    public async Task<PlaylistDto> CreateAsync(PlaylistDto playlistDto, string channelId)
    {
        Playlist playlist = playlistDto.ToPlaylistEntity();

        Channel channel = await this._channelRepository.GetAll().SingleOrDefaultAsync(channel => channel.Id == channelId);

        if(channel == null)
        {
            throw new ArgumentException("Channel does not exist.");
        }

        playlist.CreatedBy = channel;

        // TODO: Check if count of videos fetched is same with count of videos provided in DTO
        //       If not, throw exception for every video missing.
        var playlistDtoVideos = playlistDto.Videos.Select(playlistDtoVideoMapping => playlistDtoVideoMapping.Video.Id).ToHashSet();
        playlist.Videos = this._videoRepository.GetAll().Where(video => playlistDtoVideos.Contains(video.Id))
            .Select(video => new PlaylistVideoMapping
            {
                Timestamp = DateTime.UtcNow.Ticks,
                Playlist = playlist,
                Video = video
            })
            .ToList();

        return (await this._playlistRepository.CreateAsync(playlist)).ToPlaylistDto();
    }

    public async Task<PlaylistDto> EditAsync(PlaylistDto playlistDto)
    {
        Playlist playlist = playlistDto.ToPlaylistEntity();

        return (await this._playlistRepository.EditAsync(playlist)).ToPlaylistDto();
    }

    public async Task<PlaylistDto> DeleteByIdAsync(string id)
    {
        Playlist playlist = await GetByIdInternalAsync(id);

        return (await this._playlistRepository.DeleteAsync(playlist)).ToPlaylistDto();
    }

    private async Task<Playlist> GetByIdInternalAsync(string id)
    {
        return await this._playlistRepository.GetAll()
            .Include(playlist => playlist.CreatedBy)
                .ThenInclude(channel => channel.ProfilePicture)
            .Include(playlist => playlist.PlaylistThumbnail)
            .Include(playlist => playlist.Videos)
                .ThenInclude(playlistVideo => playlistVideo.Video)
                    .ThenInclude(video => video.Thumbnail)
            .Include(playlist => playlist.Videos)
                .ThenInclude(video => video.Video)
                    .ThenInclude(video => video.CreatedBy)
            .SingleOrDefaultAsync(playlist => playlist.Id == id);
    }
}