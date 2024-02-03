using MeTube.Data.Models.Comments;

namespace MeTube.Data.Repository.Comments;

public class VideoCommentRepository : MetadataBaseRepository<VideoComment>
{
    public VideoCommentRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }
}