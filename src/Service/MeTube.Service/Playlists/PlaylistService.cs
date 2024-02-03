using MeTube.Data.Models.Playlists;
using MeTube.Data.Repository.Playlists;
using MeTube.Model.Mappings.Playlists;
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
        return (await GetByIdInternalAsync(id)).ToDto();
    }

    public IQueryable<PlaylistDto> GetAll()
    {
        return _playlistRepository.GetAllAsNoTracking().Select(playlist => playlist.ToDto());
    }

    public async Task<PlaylistDto> CreateAsync(PlaylistDto playlistDto)
    {
        Playlist playlist = playlistDto.ToEntity();

        return (await _playlistRepository.CreateAsync(playlist)).ToDto();
    }

    public async Task<PlaylistDto> EditAsync(PlaylistDto playlistDto)
    {
        Playlist playlist = playlistDto.ToEntity();

        return (await _playlistRepository.EditAsync(playlist)).ToDto();
    }

    public async Task<PlaylistDto> DeleteByIdAsync(string id)
    {
        Playlist playlist = await GetByIdInternalAsync(id);

        return (await _playlistRepository.DeleteAsync(playlist)).ToDto();
    }

    private async Task<Playlist> GetByIdInternalAsync(string id)
    {
        return await _playlistRepository.GetAll()
            .SingleOrDefaultAsync(playlist => playlist.Id == id);
    }
}