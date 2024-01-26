using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Repository;

public class PlaylistCommentReactionRepository : BaseRepository<PlaylistCommentReaction>
{
    public PlaylistCommentReactionRepository(MeTubeDbContext dbContext) 
        : base(dbContext)
    {
    }
}