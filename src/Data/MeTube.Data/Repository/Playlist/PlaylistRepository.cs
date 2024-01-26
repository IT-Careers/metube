using MeTube.Data.Models.Playlists;

namespace MeTube.Data.Repository;

public class PlaylistRepository : MetadataBaseRepository<Playlist>
{
    public PlaylistRepository(MeTubeDbContext dbContext) 
        : base(dbContext)
    {
    }
}