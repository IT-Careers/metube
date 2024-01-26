namespace MeTube.Service.Models.Reactions;

public class VideoCommentReactionDto : ReactionDto
{
    public VideoCommentDto Comment { get; set; }
}