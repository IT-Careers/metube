using MeTube.Data.Models.Playlists;
using MeTube.Model.Mappings;
using MeTube.Model.Mappings.Comments;
using MeTube.Model.Mappings.Playlists;
using MeTube.Model.Mappings.Reactions;
using MeTube.Model.Mappings.Videos;
using MeTube.Service.Models.Playlist;

namespace MeTube.Model.Mappings.Playlists;

public static class PlaylistMapping
{
    public static Playlist ToEntity(this PlaylistDto playlistDto)
    {
        Playlist playlist = new Playlist();

        playlist.Id = playlistDto.Id;
        playlist.Title = playlistDto.Title;
        playlist.Description = playlistDto.Description;
        playlist.PlaylistThumbnail = playlistDto.PlaylistThumbnail.ToEntity();
        playlist.Comments = playlistDto.Comments.Select(plc => plc.ToEntity()).ToList();
        playlist.Reactions = playlistDto.Reactions.Select(plr => plr.ToEntity()).ToList();
        playlist.Videos = playlistDto.Videos.Select(videoDto => videoDto.ToEntity()).ToList();

        return playlist;
    }

    public static PlaylistDto ToDto(this Playlist playlist)
    {
        PlaylistDto playlistDto = new PlaylistDto();

        playlistDto.Id = playlist.Id;
        playlistDto.Title = playlist.Title;
        playlistDto.Description = playlist.Description;
        playlistDto.PlaylistThumbnail = playlist.PlaylistThumbnail.ToDto();
        playlistDto.Comments = playlist.Comments.Select(plc => plc.ToDto()).ToList();
        playlistDto.Reactions = playlist.Reactions.Select(plr => plr.ToDto()).ToList();
        playlistDto.Videos = playlist.Videos.Select(videoEntity => videoEntity.ToDto()).ToList();

        return playlistDto;
    }
}