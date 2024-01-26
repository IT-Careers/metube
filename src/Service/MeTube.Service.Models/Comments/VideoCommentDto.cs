using MeTube.Service.Models.Reactions;

namespace MeTube.Service.Models;

public class VideoCommentDto : CommentDto
{
    public VideoDto Video { get; set; }

    public List<VideoCommentReactionDto> Reactions { get; set; }

    public List<VideoCommentDto> Replies { get; set; }
}