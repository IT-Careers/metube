using MeTube.Service.Models;
using MeTube.Service.Models.Playlist;

namespace MeTube.Service.Playlists;

public interface IPlaylistService
{
    Task<PlaylistDto> GetByIdAsync(string id);

    IQueryable<PlaylistDto> GetAll();

    Task<PlaylistDto> CreateAsync(PlaylistDto playlistDto);

    Task<PlaylistDto> EditAsync(PlaylistDto playlistDto);

    Task<PlaylistDto> DeleteByIdAsync(string id);
}