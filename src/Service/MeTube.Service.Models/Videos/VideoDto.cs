using MeTube.Service.Models.Comments;
using MeTube.Service.Models.Reactions;

namespace MeTube.Service.Models.Videos;

public class VideoDto : MetadataBaseEntityDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public AttachmentDto VideoFile { get; set; }

    public AttachmentDto Thumbnail { get; set; }

    public List<VideoCommentDto> Comments { get; set; }

    public List<VideoReactionDto> Reactions { get; set; }
}