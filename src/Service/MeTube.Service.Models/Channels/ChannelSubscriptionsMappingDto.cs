namespace MeTube.Service.Models.Channels;

public class ChannelSubscriptionsMappingDto : BaseEntityDto
{
    public long Timestamp { get; set; }

    public ChannelDto Subscriber { get; set; }

    public ChannelDto Subscription { get; set; }
}
