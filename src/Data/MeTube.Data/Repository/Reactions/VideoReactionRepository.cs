using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Repository.Reactions;

public class VideoReactionRepository : BaseRepository<VideoReaction>, IVideoReactionRepository
{
    public VideoReactionRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }
}