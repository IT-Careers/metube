using MeTube.Data.Models.Reactions;
using MeTube.Model.Mappings.Channels;
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
        playlistReaction.Channel = playlistReactionDto.Channel.ToEntity();
        playlistReaction.Type = playlistReactionDto.Type.ToEntity();

        return playlistReaction;
    }

    public static PlaylistReactionDto ToDto(this PlaylistReaction playlistReaction)
    {
        PlaylistReactionDto playlistReactionDto = new PlaylistReactionDto();

        playlistReactionDto.Id = playlistReaction.Id;
        playlistReactionDto.Playlist = playlistReaction.Playlist.ToDto();
        playlistReactionDto.Channel = playlistReaction.Channel.ToDto();
        playlistReactionDto.Type = playlistReaction.Type.ToDto();

        return playlistReactionDto;
    }
}
