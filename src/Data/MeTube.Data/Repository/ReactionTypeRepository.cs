using MeTube.Data.Models.Reactions;

namespace MeTube.Data.Repository;

public class ReactionTypeRepository : BaseRepository<ReactionType>
{
    public ReactionTypeRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }
}