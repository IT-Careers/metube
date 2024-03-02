using MeTube.Data.Models.Reactions;
using MeTube.Service.Mappings.Channels;
using MeTube.Service.Mappings.Playlists;
using MeTube.Service.Models.Reactions;

namespace MeTube.Service.Mappings.Reactions;

public static class PlaylistReactionMapping
{
    public static PlaylistReaction ToPlaylistReactionEntity(this PlaylistReactionDto playlistReactionDto)
    {
        PlaylistReaction playlistReaction = new PlaylistReaction();

        playlistReaction.Id = playlistReactionDto.Id;
        playlistReaction.Playlist = playlistReactionDto.Playlist?.ToPlaylistEntity();
        playlistReaction.Channel = playlistReactionDto.Channel?.ToChannelEntity();
        playlistReaction.Type = playlistReactionDto.Type?.ToReactionTypeEntity();

        return playlistReaction;
    }

    public static PlaylistReactionDto ToPlaylistReactionDto(this PlaylistReaction playlistReaction, bool includePlaylist = false,
        bool includeChannel = true)
    {
        PlaylistReactionDto playlistReactionDto = new PlaylistReactionDto();

        playlistReactionDto.Id = playlistReaction.Id;
        playlistReactionDto.Type = playlistReaction.Type?.ToReactionTypeDto();

        playlistReactionDto.Playlist = includePlaylist
            ? playlistReaction.Playlist?.ToPlaylistDto(includeReactions: false)
            : null;

        playlistReactionDto.Channel = includeChannel
            ? playlistReaction.Channel?.ToChannelDto(includePlaylistReactions: false)
            : null;


        return playlistReactionDto;
    }
}