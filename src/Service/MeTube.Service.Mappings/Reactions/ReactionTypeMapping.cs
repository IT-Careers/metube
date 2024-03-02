using MeTube.Data.Models.Reactions;
using MeTube.Service.Models.Reactions;

namespace MeTube.Service.Mappings.Reactions;

public static class ReactionTypeMapping
{
    public static ReactionType ToReactionTypeEntity(this ReactionTypeDto reactionTypeDto)
    {
        ReactionType reactionType = new ReactionType();

        reactionType.Id = reactionTypeDto.Id ?? reactionType.Id;
        reactionType.Type = reactionTypeDto.Type;
        reactionType.ReactionIcon = reactionTypeDto.ReactionIcon?.ToAttachmentEntity();

        return reactionType;
    }

    public static ReactionTypeDto ToReactionTypeDto(this ReactionType reactionType)
    {
        ReactionTypeDto reactionTypeDto = new ReactionTypeDto();

        reactionTypeDto.Id = reactionType.Id;
        reactionTypeDto.Type = reactionType.Type;
        reactionTypeDto.ReactionIcon = reactionType.ReactionIcon?.ToAttachmentDto();

        return reactionTypeDto;
    }
}
