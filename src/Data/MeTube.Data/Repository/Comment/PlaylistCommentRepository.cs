using MeTube.Data.Models.Comments;

namespace MeTube.Data.Repository;

public class PlaylistCommentRepository : MetadataBaseRepository<PlaylistComment>
{
    public PlaylistCommentRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }
}