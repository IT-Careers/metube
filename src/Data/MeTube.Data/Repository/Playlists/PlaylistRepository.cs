using MeTube.Data.Models.Playlists;

namespace MeTube.Data.Repository.Playlists;

public class PlaylistRepository : MetadataBaseRepository<Playlist>
{
    public PlaylistRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }
}