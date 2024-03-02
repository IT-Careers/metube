using MeTube.Data.Models.Channels;

namespace MeTube.Data.Repository.Channels;

public class ChannelSubscriptionMappingRepository : BaseRepository<ChannelSubscriptionsMapping>
{
    public ChannelSubscriptionMappingRepository(MeTubeDbContext dbContext) : base(dbContext)
    {
    }
}
