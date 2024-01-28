using MeTube.Data.Models.Playlists;
using MeTube.Data.Repository;
using MeTube.Model.Mappings.Playlists;
using MeTube.Service.Models.Playlist;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service;

public class PlaylistService : IPlaylistService
{
    private readonly PlaylistRepository _playlistRepository;

    public PlaylistService(PlaylistRepository playlistRepository)
    {
        _playlistRepository = playlistRepository;
    }

    public async Task<PlaylistDto> GetByIdAsync(string id)
    {
        return (await this.GetByIdInternalAsync(id)).ToDto();
    }

    public IQueryable<PlaylistDto> GetAll()
    {
        return this._playlistRepository.GetAllAsNoTracking().Select(playlist => playlist.ToDto());
    }

    public async Task<PlaylistDto> CreateAsync(PlaylistDto playlistDto)
    {
        Playlist playlist = playlistDto.ToEntity();

        return (await this._playlistRepository.CreateAsync(playlist)).ToDto();
    }

    public async Task<PlaylistDto> EditAsync(PlaylistDto playlistDto)
    {
        Playlist playlist = playlistDto.ToEntity();

        return (await this._playlistRepository.EditAsync(playlist)).ToDto();
    }

    public async Task<PlaylistDto> DeleteByIdAsync(string id)
    {
        Playlist playlist = await this.GetByIdInternalAsync(id);

        return (await this._playlistRepository.DeleteAsync(playlist)).ToDto();
    }

    private async Task<Playlist> GetByIdInternalAsync(string id)
    {
        return await this._playlistRepository.GetAll()
            .SingleOrDefaultAsync(playlist => playlist.Id == id);
    }
}