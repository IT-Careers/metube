using MeTube.Service.Models.Playlist;
using MeTube.Service.Models.Reactions;

namespace MeTube.Service.Models.Comments;

public class PlaylistCommentDto : CommentDto
{
    public PlaylistCommentDto()
    {
        Reactions = new List<PlaylistCommentReactionDto>();
        Replies = new List<PlaylistCommentDto>();
    }
    
    public PlaylistDto Playlist { get; set; }

    public List<PlaylistCommentReactionDto> Reactions { get; set; }
        
    public List<PlaylistCommentDto> Replies { get; set; }
}