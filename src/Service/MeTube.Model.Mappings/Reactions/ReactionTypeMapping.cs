using MeTube.Data.Models.Reactions;
using MeTube.Service.Models.Reactions;

namespace MeTube.Model.Mappings.Reactions;

public static class ReactionTypeMapping
{
    public static ReactionType ToEntity(this ReactionTypeDto reactionTypeDto)
    {
        ReactionType reactionType = new ReactionType();

        reactionType.Id = reactionTypeDto.Id ?? reactionType.Id;
        reactionType.Type = reactionTypeDto.Type;
        reactionType.ReactionIcon = reactionTypeDto.ReactionIcon.ToEntity();

        return reactionType;
    }

    public static ReactionTypeDto ToDto(this ReactionType reactionType)
    {
        ReactionTypeDto reactionTypeDto = new ReactionTypeDto();

        reactionTypeDto.Id = reactionType.Id;
        reactionTypeDto.Type = reactionType.Type;
        reactionTypeDto.ReactionIcon = reactionType.ReactionIcon.ToDto();

        return reactionTypeDto;
    }
}
