using MeTube.Data.Models.Comments;

namespace MeTube.Data.Repository.Comments;

public class PlaylistCommentRepository : MetadataBaseRepository<PlaylistComment>
{
    public PlaylistCommentRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }
}