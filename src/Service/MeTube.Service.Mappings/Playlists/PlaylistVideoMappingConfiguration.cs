using MeTube.Data.Models.Playlists;
using MeTube.Service.Mappings.Videos;
using MeTube.Service.Models.Playlist;

namespace MeTube.Service.Mappings.Playlists;

public static class PlaylistVideoMappingConfiguration
{
    public static PlaylistVideoMapping ToPlaylistVideoMappingEntity(this PlaylistVideoMappingDto playlistVideoMappingDto)
    {
        PlaylistVideoMapping playlistVideoMapping = new PlaylistVideoMapping();

        playlistVideoMapping.Id = playlistVideoMappingDto.Id ?? playlistVideoMappingDto.Id;
        playlistVideoMapping.Timestamp = playlistVideoMappingDto.Timestamp;
        playlistVideoMapping.Video = playlistVideoMappingDto.Video.ToVideoEntity();
        playlistVideoMapping.Playlist = playlistVideoMappingDto.Playlist.ToPlaylistEntity();

        return playlistVideoMapping;
    }

    public static PlaylistVideoMappingDto ToPlaylistVideoMappingDto(this PlaylistVideoMapping playlistVideoMapping, bool includeVideos = true, bool includePlaylist = true)
    {
        PlaylistVideoMappingDto playlistVideoMappingDto = new PlaylistVideoMappingDto();

        playlistVideoMappingDto.Id = playlistVideoMapping.Id;
        playlistVideoMappingDto.Timestamp = playlistVideoMapping.Timestamp;
        playlistVideoMappingDto.Video = includeVideos 
            ? playlistVideoMapping.Video.ToVideoDto()
            : null;
        playlistVideoMappingDto.Playlist = includePlaylist 
            ? playlistVideoMapping.Playlist.ToPlaylistDto()
            : null;

        return playlistVideoMappingDto;
    }
}
