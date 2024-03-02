using MeTube.Data.Models.Reactions;
using MeTube.Service.Mappings;
using MeTube.Service.Mappings.Channels;
using MeTube.Service.Mappings.Comments;
using MeTube.Service.Mappings.Reactions;
using MeTube.Service.Models.Reactions;

namespace MeTube.Service.Mappings.Reactions;

public static class VideoCommentReactionMapping
{
    public static VideoCommentReaction ToVideoCommentReactionEntity(this VideoCommentReactionDto VideoCommentReactionDto)
    {
        VideoCommentReaction VideoCommentReaction = new VideoCommentReaction();

        VideoCommentReaction.Id = VideoCommentReactionDto.Id;
        VideoCommentReaction.Comment = VideoCommentReactionDto.Comment?.ToVideoCommentEntity();
        VideoCommentReaction.Channel = VideoCommentReactionDto.Channel?.ToChannelEntity();
        VideoCommentReaction.Type = VideoCommentReactionDto.Type?.ToReactionTypeEntity();

        return VideoCommentReaction;
    }

    public static VideoCommentReactionDto ToVideoCommentReactionDto(this VideoCommentReaction VideoCommentReaction,
        bool includeComments = true, bool includeChannel = true)
    {
        VideoCommentReactionDto VideoCommentReactionDto = new VideoCommentReactionDto();

        VideoCommentReactionDto.Id = VideoCommentReaction.Id;
        VideoCommentReactionDto.Channel = includeChannel
            ? VideoCommentReaction.Channel?.ToChannelDto()
            : null;
        VideoCommentReactionDto.Type = VideoCommentReaction.Type?.ToReactionTypeDto();

        VideoCommentReactionDto.Comment = includeComments
            ? VideoCommentReaction.Comment?.ToVideoCommentDto(includeReactions: false)
            : null;

        return VideoCommentReactionDto;
    }
}