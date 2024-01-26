using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Repository;

public class PlaylistReactionRepository : BaseRepository<PlaylistReaction>
{
    public PlaylistReactionRepository(MeTubeDbContext dbContext) 
        : base(dbContext)
    {
    }
}