using MeTube.Service.Models.Videos;

namespace MeTube.Service.Models.Reactions;

public class VideoReactionDto : ReactionDto
{
    public VideoDto Video { get; set; }
}