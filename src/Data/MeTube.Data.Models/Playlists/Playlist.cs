using MeTube.Data.Models.Comments;
using MeTube.Data.Models.Reactions;
using MeTube.Data.Models.Videos;

namespace MeTube.Data.Models.Playlists
{
    public class Playlist : MetadataBaseEntity
    {
        public Playlist()
        {
            Reactions = new List<PlaylistReaction>();
            Comments = new List<PlaylistComment>();
            Videos = new List<PlaylistVideoMapping>();
        }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public Attachment PlaylistThumbnail { get; set; } // TODO: If null just make a thumbnail of 4 top videos

        public List<PlaylistReaction> Reactions { get; set; }

        public List<PlaylistComment> Comments { get; set; }

        public List<PlaylistVideoMapping> Videos { get; set; }
    }
}
