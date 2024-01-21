namespace MeTube.Service.Models;

public class CommentDto : BaseEntityDto
{
    public string Content { get; set; }

    public MeTubeUserDto Poster { get; set; }
}