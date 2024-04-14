using MeTube.Data.Models.Channels;

namespace MeTube.Data.Repository.Channels;

public class ChannelRepository : BaseRepository<Channel>, IChannelRepository
{
    public ChannelRepository(MeTubeDbContext dbContext) : base(dbContext)
    {
    }
}
