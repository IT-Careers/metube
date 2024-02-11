using MeTube.Service.Models.Reactions;
using MeTube.Service.Models.Videos;

namespace MeTube.Service.Models.Comments;

public class VideoCommentDto : CommentDto
{
    public VideoCommentDto()
    {
        Reactions = new List<VideoCommentReactionDto>();
        Replies = new List<VideoCommentDto>();
    }
    
    public VideoDto Video { get; set; }

    public List<VideoCommentReactionDto> Reactions { get; set; }

    public List<VideoCommentDto> Replies { get; set; }
}