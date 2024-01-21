using MeTube.Data.Models;

namespace MeTube.Data.Repository;

public class AttachmentRepository : BaseRepository<Attachment>
{
    public AttachmentRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }
}