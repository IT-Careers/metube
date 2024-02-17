using MeTube.Data.Models.Channels;
using MeTube.Data.Models.Videos;
using MeTube.Data.Repository.Channels;
using MeTube.Data.Repository.Videos;
using MeTube.Model.Mappings.Videos;
using MeTube.Service.Channels;
using MeTube.Service.Models.Channels;
using MeTube.Service.Models.Videos;
using MeTube.Service.Playlists;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service.Videos;

public class VideoService : IVideoService
{
    private readonly VideoRepository _videoRepository;

    private readonly ChannelRepository _channelRepository;

    private readonly IPlaylistService _playlistService;

    public VideoService(VideoRepository videoRepository, ChannelRepository channelRepository, IPlaylistService playlistService)
    {
        this._videoRepository = videoRepository;
        this._channelRepository = channelRepository;
        this._playlistService = playlistService;
    }

    public async Task<VideoDto> GetByIdAsync(string id)
    {
        return (await this.GetByIdInternalAsync(id)).ToDto();
    }

    public IQueryable<VideoDto> GetAll()
    {
        return this._videoRepository.GetAllAsNoTracking()
            .Include(video => video.VideoFile)
            .Include(video => video.Thumbnail)
            .Include(video => video.CreatedBy).ThenInclude(channel => channel.ProfilePicture)
            .Include(video => video.Comments)
            .Include(video => video.Reactions)
            .Select(video => video.ToDto(true, true));
    }

    public async Task<ICollection<VideoDto>> GetAllPlaylistVideos(string playlistId)
    {
        return (await this._playlistService.GetByIdAsync(playlistId)).Videos;
    }

    public async Task<VideoDto> CreateAsync(VideoDto videoDto, string userId)
    {
        Channel? channel = this._channelRepository.GetAll()
            .Include(channel => channel.User)
            .SingleOrDefault(channel => channel.User.Id == userId);

        if (channel == null)
        {
            throw new Exception("Channel with the given user id does not exist.");
        }

        Video video = videoDto.ToEntity();
        video.CreatedBy = channel;

        return (await _videoRepository.CreateAsync(video)).ToDto(true);
    }

    public async Task<VideoDto> EditAsync(VideoDto videoDto)
    {
        Video video = videoDto.ToEntity();

        return (await _videoRepository.EditAsync(video)).ToDto();
    }

    public async Task<VideoDto> DeleteByIdAsync(string id)
    {
        Video video = await this.GetByIdInternalAsync(id);

        return (await _videoRepository.DeleteAsync(video)).ToDto();
    }

    private async Task<Video> GetByIdInternalAsync(string id)
    {
        return await this._videoRepository.GetAll()
            .SingleOrDefaultAsync(video => video.Id == id);
    }
}