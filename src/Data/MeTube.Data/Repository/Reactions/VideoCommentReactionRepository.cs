using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Repository.Reactions;

public class VideoCommentReactionRepository : BaseRepository<VideoCommentReaction>
{
    public VideoCommentReactionRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }
}