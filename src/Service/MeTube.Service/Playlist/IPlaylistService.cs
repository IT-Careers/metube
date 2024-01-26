using MeTube.Service.Models;
using MeTube.Service.Models.Playlist;

namespace MeTube.Service;

public interface IPlaylistService
{
    Task<PlaylistDto> GetById(string id);
    Task<PlaylistDto> Create(PlaylistDto playlistDto);
    Task<PlaylistDto> Edit(PlaylistDto playlistDto);
    Task<PlaylistDto> DeleteById(string id);
}