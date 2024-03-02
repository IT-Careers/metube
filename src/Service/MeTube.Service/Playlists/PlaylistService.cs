using MeTube.Data.Models.Playlists;
using MeTube.Data.Repository.Playlists;
using MeTube.Service.Mappings.Playlists;
using MeTube.Service.Models.Playlist;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service.Playlists;

public class PlaylistService : IPlaylistService
{
    private readonly PlaylistRepository _playlistRepository;

    public PlaylistService(PlaylistRepository playlistRepository)
    {
        _playlistRepository = playlistRepository;
    }

    public async Task<PlaylistDto> GetByIdAsync(string id)
    {
        return (await GetByIdInternalAsync(id)).ToPlaylistDto();
    }

    public IQueryable<PlaylistDto> GetAll()
    {
        return _playlistRepository.GetAllAsNoTracking()
            .Select(playlist => playlist.ToPlaylistDto(true, true, true));
    }

    public async Task<PlaylistDto> CreateAsync(PlaylistDto playlistDto)
    {
        Playlist playlist = playlistDto.ToPlaylistEntity();

        return (await _playlistRepository.CreateAsync(playlist)).ToPlaylistDto();
    }

    public async Task<PlaylistDto> EditAsync(PlaylistDto playlistDto)
    {
        Playlist playlist = playlistDto.ToPlaylistEntity();

        return (await _playlistRepository.EditAsync(playlist)).ToPlaylistDto();
    }

    public async Task<PlaylistDto> DeleteByIdAsync(string id)
    {
        Playlist playlist = await GetByIdInternalAsync(id);

        return (await _playlistRepository.DeleteAsync(playlist)).ToPlaylistDto();
    }

    private async Task<Playlist> GetByIdInternalAsync(string id)
    {
        return await _playlistRepository.GetAll()
            .SingleOrDefaultAsync(playlist => playlist.Id == id);
    }
}