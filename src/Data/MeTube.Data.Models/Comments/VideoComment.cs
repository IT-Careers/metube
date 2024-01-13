using MeTube.Data.Models.Reactions;
using MeTube.Data.Models.Videos;

namespace MeTube.Data.Models.Comments
{
    public class VideoComment : Comment
    {
        public Video Video { get; set; }

        public List<VideoCommentReaction> Reactions { get; set; }
    }
}
