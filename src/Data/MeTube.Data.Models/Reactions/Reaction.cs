using MeTube.Data.Models.Channels;

namespace MeTube.Data.Models.Reactions;

public abstract class Reaction : BaseEntity
{
    public Channel Channel { get; set; }

    public ReactionType Type { get; set; }
}
