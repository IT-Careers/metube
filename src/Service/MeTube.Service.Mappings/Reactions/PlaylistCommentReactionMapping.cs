using MeTube.Data.Models.Reactions;
using MeTube.Service.Mappings;
using MeTube.Service.Mappings.Channels;
using MeTube.Service.Mappings.Comments;
using MeTube.Service.Mappings.Reactions;
using MeTube.Service.Models.Reactions;

namespace MeTube.Service.Mappings.Reactions;

public static class PlaylistCommentReactionMapping
{
    public static PlaylistCommentReaction ToPlaylistCommentReactionEntity(this PlaylistCommentReactionDto playlistCommentReactionDto)
    {
        PlaylistCommentReaction playlistCommentReaction = new PlaylistCommentReaction();

        playlistCommentReaction.Id = playlistCommentReactionDto.Id;
        playlistCommentReaction.Comment = playlistCommentReactionDto.Comment?.ToPlaylistCommentEntity();
        playlistCommentReaction.Channel = playlistCommentReactionDto.Channel?.ToChannelEntity();
        playlistCommentReaction.Type = playlistCommentReactionDto.Type?.ToReactionTypeEntity();

        return playlistCommentReaction;
    }

    public static PlaylistCommentReactionDto ToPlaylistCommentReactionDto(this PlaylistCommentReaction playlistCommentReaction,
        bool includeComment = true)
    {
        PlaylistCommentReactionDto playlistCommentReactionDto = new PlaylistCommentReactionDto();

        playlistCommentReactionDto.Id = playlistCommentReaction.Id;
        playlistCommentReactionDto.Channel = playlistCommentReaction.Channel?.ToChannelDto();
        playlistCommentReactionDto.Type = playlistCommentReaction.Type?.ToReactionTypeDto();

        playlistCommentReactionDto.Comment = includeComment
            ? playlistCommentReaction.Comment?.ToPlaylistCommentDto(includeReactions: false)
            : null;

        return playlistCommentReactionDto;
    }
}