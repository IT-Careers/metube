using MeTube.Data.Models.Comments;
using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Models.Videos
{
    public class Video : MetadataBaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Attachment? VideoFile { get; set; }

        public Attachment? Thumbnail { get; set; }

        public List<VideoComment> Comments { get; set; }

        public List<VideoReaction> Reactions { get; set; }
    }
}
