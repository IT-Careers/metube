using MeTube.Data.Models.Reactions;
using MeTube.Model.Mappings;
using MeTube.Model.Mappings.Channels;
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
        VideoCommentReaction.Channel = VideoCommentReactionDto.Channel.ToEntity();
        VideoCommentReaction.Type = VideoCommentReactionDto.Type.ToEntity();

        return VideoCommentReaction;
    }

    public static VideoCommentReactionDto ToDto(this VideoCommentReaction VideoCommentReaction)
    {
        VideoCommentReactionDto VideoCommentReactionDto = new VideoCommentReactionDto();

        VideoCommentReactionDto.Id = VideoCommentReaction.Id;
        VideoCommentReactionDto.Comment = VideoCommentReaction.Comment.ToDto();
        VideoCommentReactionDto.Channel = VideoCommentReaction.Channel.ToDto();
        VideoCommentReactionDto.Type = VideoCommentReaction.Type.ToDto();

        return VideoCommentReactionDto;
    }
}
