using MeTube.Data.Models.Videos;

namespace MeTube.Data.Models.Playlists;

public class PlaylistVideoMapping : BaseEntity
{
    public long Timestamp { get; set; }
    
    public Playlist Playlist { get; set; }

    public Video Video { get; set; }
}
