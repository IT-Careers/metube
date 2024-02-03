namespace MeTube.Data.Models.Channels
{
    public class ChannelSubscriptionsMapping : BaseEntity
    {
        public long Timestamp { get; set; }

        public Channel Subscriber { get; set; }

        public Channel Subscription { get; set; }
    }
}
