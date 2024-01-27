using MeTube.Data.Models.Reactions;
using MeTube.Model.Mappings;
using MeTube.Model.Mappings.Comments;
using MeTube.Model.Mappings.Reactions;
using MeTube.Service.Models.Reactions;

namespace MeTube.Model.Mappings.Reactions;

public static class VideoCommentReactionMapping
{
    public static VideoCommentReaction ToEntity(this VideoCommentReactionDto VideoCommentReactionDto)
    {
        VideoCommentReaction VideoCommentReaction = new VideoCommentReaction();

        VideoCommentReaction.Id = VideoCommentReactionDto.Id;
        VideoCommentReaction.Comment = VideoCommentReactionDto.Comment.ToEntity();
        VideoCommentReaction.User = VideoCommentReactionDto.User.ToEntity();
        VideoCommentReaction.Type = VideoCommentReactionDto.Type.ToEntity();

        return VideoCommentReaction;
    }

    public static VideoCommentReactionDto ToDto(this VideoCommentReaction VideoCommentReaction)
    {
        VideoCommentReactionDto VideoCommentReactionDto = new VideoCommentReactionDto();

        VideoCommentReactionDto.Id = VideoCommentReaction.Id;
        VideoCommentReactionDto.Comment = VideoCommentReaction.Comment.ToDto();
        VideoCommentReactionDto.User = VideoCommentReaction.User.ToDto();
        VideoCommentReactionDto.Type = VideoCommentReaction.Type.ToDto();

        return VideoCommentReactionDto;
    }
}
