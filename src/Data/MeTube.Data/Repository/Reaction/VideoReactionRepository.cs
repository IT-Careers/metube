using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Repository;

public class VideoReactionRepository : BaseRepository<VideoReaction>
{
    public VideoReactionRepository(MeTubeDbContext dbContext) 
        : base(dbContext)
    {
    }
}