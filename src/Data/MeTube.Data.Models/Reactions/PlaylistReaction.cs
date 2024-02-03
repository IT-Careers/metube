using MeTube.Data.Models.Playlists;

namespace MeTube.Data.Models.Reactions;

public class PlaylistReaction : Reaction
{
    public Playlist Playlist { get; set; }
}
