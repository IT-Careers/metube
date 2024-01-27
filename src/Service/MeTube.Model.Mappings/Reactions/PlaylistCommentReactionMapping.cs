using MeTube.Data.Models.Reactions;
using MeTube.Model.Mappings;
using MeTube.Model.Mappings.Comments;
using MeTube.Model.Mappings.Reactions;
using MeTube.Service.Models.Reactions;

namespace MeTube.Model.Mappings.Reactions;

public static class PlaylistCommentReactionMapping
{
    public static PlaylistCommentReaction ToEntity(this PlaylistCommentReactionDto playlistCommentReactionDto)
    {
        PlaylistCommentReaction playlistCommentReaction = new PlaylistCommentReaction();

        playlistCommentReaction.Id = playlistCommentReactionDto.Id;
        playlistCommentReaction.Comment = playlistCommentReactionDto.Comment.ToEntity();
        playlistCommentReaction.User = playlistCommentReactionDto.User.ToEntity();
        playlistCommentReaction.Type = playlistCommentReactionDto.Type.ToEntity();

        return playlistCommentReaction;
    }

    public static PlaylistCommentReactionDto ToDto(this PlaylistCommentReaction playlistCommentReaction)
    {
        PlaylistCommentReactionDto playlistCommentReactionDto = new PlaylistCommentReactionDto();

        playlistCommentReactionDto.Id = playlistCommentReaction.Id;
        playlistCommentReactionDto.Comment = playlistCommentReaction.Comment.ToDto();
        playlistCommentReactionDto.User = playlistCommentReaction.User.ToDto();
        playlistCommentReactionDto.Type = playlistCommentReaction.Type.ToDto();

        return playlistCommentReactionDto;
    }
}
