using MeTube.Data.Models.Playlists;
using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Models.Comments
{
    public class PlaylistComment : Comment
    {
        public Playlist Playlist { get; set; }

        public List<PlaylistCommentReaction> Reactions { get; set; }
    }
}
