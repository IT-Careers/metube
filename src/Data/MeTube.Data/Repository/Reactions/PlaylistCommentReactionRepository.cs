using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Repository.Reactions;

public class PlaylistCommentReactionRepository : BaseRepository<PlaylistCommentReaction>
{
    public PlaylistCommentReactionRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }
}