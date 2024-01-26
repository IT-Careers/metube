using MeTube.Service.Models.Playlist;

namespace MeTube.Service.Models.Reactions;

public class PlaylistReactionDto : ReactionDto
{
    public PlaylistDto Playlist { get; set; }
}