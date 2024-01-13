using MeTube.Data.Models.Comments;

namespace MeTube.Data.Models.Reactions
{
    public class VideoCommentReaction : Reaction
    {
        public VideoComment Comment { get; set; }
    }
}
