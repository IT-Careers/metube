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

    public static PlaylistReactionDto ToDto(this PlaylistReaction playlistReaction, bool includePlaylist = false,
        bool includeChannel = true)
    {
        PlaylistReactionDto playlistReactionDto = new PlaylistReactionDto();

        playlistReactionDto.Id = playlistReaction.Id;
        playlistReactionDto.Type = playlistReaction.Type.ToDto();

        playlistReactionDto.Playlist = includePlaylist
            ? playlistReaction.Playlist.ToDto(includeReactions: false)
            : null;

        playlistReactionDto.Channel = includeChannel
            ? playlistReaction.Channel.ToDto(includePlaylistReactions: false)
            : null;


        return playlistReactionDto;
    }
}