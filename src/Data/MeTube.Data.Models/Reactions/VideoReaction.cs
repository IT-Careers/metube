using MeTube.Data.Models.Videos;

namespace MeTube.Data.Models.Reactions;

public class VideoReaction : Reaction
{
    public Video Video { get; set; }
}
