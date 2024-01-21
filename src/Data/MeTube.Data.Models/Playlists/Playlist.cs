using MeTube.Data.Models.Comments;
using MeTube.Data.Models.Reactions;
using MeTube.Data.Models.Videos;

namespace MeTube.Data.Models.Playlists
{
    public class Playlist : MetadataBaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Attachment PlaylistThumbnail { get; set; } // TODO: If null just make a thumbnail of 4 top videos

        public List<PlaylistReaction> Reactions { get; set; }

        public List<PlaylistComment> Comments { get; set; }

        public List<Video> Videos { get; set; }
    }
}
