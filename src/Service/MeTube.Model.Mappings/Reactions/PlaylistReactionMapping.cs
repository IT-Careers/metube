using MeTube.Data.Models.Reactions;
using MeTube.Model.Mappings.Playlists;
using MeTube.Service.Models.Reactions;

namespace MeTube.Model.Mappings.Reactions;

public static class PlaylistReactionMapping
{
    public static PlaylistReaction ToEntity(this PlaylistReactionDto playlistReactionDto)
    {
        PlaylistReaction playlistReaction = new PlaylistReaction();

        playlistReaction.Id = playlistReactionDto.Id;
        playlistReaction.Playlist = playlistReactionDto.Playlist.ToEntity();
        playlistReaction.User = playlistReactionDto.User.ToEntity();
        playlistReaction.Type = playlistReactionDto.Type.ToEntity();

        return playlistReaction;
    }

    public static PlaylistReactionDto ToDto(this PlaylistReaction playlistReaction)
    {
        PlaylistReactionDto playlistReactionDto = new PlaylistReactionDto();

        playlistReactionDto.Id = playlistReaction.Id;
        playlistReactionDto.Playlist = playlistReaction.Playlist.ToDto();
        playlistReactionDto.User = playlistReaction.User.ToDto();
        playlistReactionDto.Type = playlistReaction.Type.ToDto();

        return playlistReactionDto;
    }
}
