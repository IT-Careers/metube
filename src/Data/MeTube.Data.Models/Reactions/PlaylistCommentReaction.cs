using MeTube.Data.Models.Comments;

namespace MeTube.Data.Models.Reactions;

public class PlaylistCommentReaction : Reaction
{
    public PlaylistComment Comment { get; set; }
}
