using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Repository;

public class VideoCommentReactionRepository : BaseRepository<VideoCommentReaction>
{
    public VideoCommentReactionRepository(MeTubeDbContext dbContext) 
        : base(dbContext)
    {
    }
}