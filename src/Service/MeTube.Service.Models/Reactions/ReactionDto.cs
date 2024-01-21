using MeTube.Data.Models;

namespace MeTube.Service.Models.Reactions;

public class ReactionDto : BaseEntityDto
{
    public MeTubeUserDto User { get; set; }

    public ReactionTypeDto Type { get; set; }
}