using MeTube.Data.Models.Channels;
using MeTube.Service.Models.Channels;

namespace MeTube.Model.Mappings.Channels;

public static class ChannelSubscriptionsMappingConfiguration
{
    public static ChannelSubscriptionsMapping ToEntity(
        this ChannelSubscriptionsMappingDto channelSubscriptionsMappingDto)
    {
        ChannelSubscriptionsMapping channelSubscriptionsMapping = new ChannelSubscriptionsMapping();

        channelSubscriptionsMapping.Id = channelSubscriptionsMappingDto.Id ?? channelSubscriptionsMapping.Id;
        channelSubscriptionsMapping.Timestamp = channelSubscriptionsMappingDto.Timestamp;
        channelSubscriptionsMapping.Subscriber = channelSubscriptionsMappingDto.Subscriber.ToEntity();
        channelSubscriptionsMapping.Subscription = channelSubscriptionsMappingDto.Subscription.ToEntity();

        return channelSubscriptionsMapping;
    }

    public static ChannelSubscriptionsMappingDto ToDto(this ChannelSubscriptionsMapping channelSubscriptionsMapping,
        bool includeSubscribers = true, bool includeSubscriptions = true)
    {
        ChannelSubscriptionsMappingDto channelSubscriptionsMappingDto = new ChannelSubscriptionsMappingDto();

        channelSubscriptionsMappingDto.Id = channelSubscriptionsMapping.Id;
        channelSubscriptionsMappingDto.Timestamp = channelSubscriptionsMapping.Timestamp;
        
        channelSubscriptionsMappingDto.Subscriber = includeSubscribers
            ? channelSubscriptionsMapping.Subscriber.ToDto(includeSubscribers: false, includeSubscriptions: false)
            : null;

        channelSubscriptionsMappingDto.Subscription = includeSubscriptions
            ? channelSubscriptionsMapping.Subscription.ToDto(includeSubscribers: false, includeSubscriptions: false)
            : null;

        return channelSubscriptionsMappingDto;
    }
}