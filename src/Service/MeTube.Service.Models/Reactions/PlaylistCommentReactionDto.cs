using MeTube.Service.Models.Channels;
using MeTube.Service.Models.Comments;

namespace MeTube.Service.Models.Reactions;

public class PlaylistCommentReactionDto : ReactionDto
{
    public PlaylistCommentDto Comment { get; set; }
    public ChannelDto Channel { get; set; }
}