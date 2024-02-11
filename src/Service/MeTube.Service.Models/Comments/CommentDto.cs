using MeTube.Service.Models.Channels;

namespace MeTube.Service.Models.Comments;

public class CommentDto : MetadataBaseEntityDto
{
    public string Content { get; set; }
}