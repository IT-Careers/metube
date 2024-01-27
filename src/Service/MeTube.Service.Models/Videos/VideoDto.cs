using MeTube.Service.Models.Reactions;

namespace MeTube.Service.Models;

public class VideoDto : BaseEntityDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public AttachmentDto VideoFile { get; set; }

    public AttachmentDto ThumbnailImage { get; set; }

    public List<VideoCommentDto> Comments { get; set; }

    public List<VideoReactionDto> Reactions { get; set; }
}