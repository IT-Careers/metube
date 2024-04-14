using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Repository.Reactions;

public class ReactionTypeRepository : BaseRepository<ReactionType>, IReactionTypeRepository
{
    public ReactionTypeRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }
}