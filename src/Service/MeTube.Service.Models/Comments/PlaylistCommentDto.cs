using MeTube.Service.Models.Playlist;
using MeTube.Service.Models.Reactions;

namespace MeTube.Service.Models;

public class PlaylistCommentDto : CommentDto
{
    public PlaylistDto Playlist { get; set; }

    public List<PlaylistCommentReactionDto> Reactions { get; set; }
        
    public List<PlaylistCommentDto> Replies { get; set; }
}