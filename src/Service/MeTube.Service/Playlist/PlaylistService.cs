using MeTube.Data.Models.Playlists;
using MeTube.Data.Repository;
using MeTube.Model.Mappings.Playlists;
using MeTube.Service.Models.Playlist;

namespace MeTube.Service;

public class PlaylistService : IPlaylistService
{
    private readonly PlaylistRepository _playlistRepository;

    public PlaylistService(PlaylistRepository playlistRepository)
    {
        _playlistRepository = playlistRepository;
    }

    public async Task<PlaylistDto> GetById(string id)
    {
        return PlaylistMapping.ToDto(GetByIdInternal(id));
    }

    public async Task<PlaylistDto> Create(PlaylistDto playlistDto)
    {
        Playlist playlist = PlaylistMapping.ToEntity(playlistDto);

        return PlaylistMapping.ToDto(await _playlistRepository.CreateAsync(playlist));
    }

    public async Task<PlaylistDto> Edit(PlaylistDto playlistDto)
    {
        Playlist playlist = PlaylistMapping.ToEntity(playlistDto);

        return PlaylistMapping.ToDto(await _playlistRepository.EditAsync(playlist));
    }

    public async Task<PlaylistDto> DeleteById(string id)
    {
        Playlist playlist = GetByIdInternal(id);

        return PlaylistMapping.ToDto(await _playlistRepository.DeleteAsync(playlist));
    }

    private Playlist GetByIdInternal(string id)
    {
        return _playlistRepository.GetAll()
            .Result
            .First(playlist => playlist.Id == id);
    }
}