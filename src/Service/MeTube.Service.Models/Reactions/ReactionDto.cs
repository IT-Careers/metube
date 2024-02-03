using MeTube.Data.Models;
using MeTube.Service.Models.Channels;

namespace MeTube.Service.Models.Reactions;

public class ReactionDto : BaseEntityDto
{
    public ChannelDto Channel { get; set; }

    public ReactionTypeDto Type { get; set; }
}