using MeTube.Data.Models.Playlists;
using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Models.Comments
{
    public class PlaylistComment : Comment
    {
        public PlaylistComment()
        {
            Reactions = new List<PlaylistCommentReaction>();
            Replies = new List<PlaylistComment>();
        }
        
        public Playlist Playlist { get; set; }

        public List<PlaylistCommentReaction> Reactions { get; set; }
        
        public List<PlaylistComment> Replies { get; set; }
    }
}
