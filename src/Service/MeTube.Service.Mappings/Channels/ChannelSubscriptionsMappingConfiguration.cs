using MeTube.Data.Models.Channels;
using MeTube.Service.Models.Channels;

namespace MeTube.Service.Mappings.Channels;

public static class ChannelSubscriptionsMappingConfiguration
{
    public static ChannelSubscriptionsMapping ToChannelSubscriptionsMappingEntity(
        this ChannelSubscriptionsMappingDto channelSubscriptionsMappingDto)
    {
        ChannelSubscriptionsMapping channelSubscriptionsMapping = new ChannelSubscriptionsMapping();

        channelSubscriptionsMapping.Id = channelSubscriptionsMappingDto.Id ?? channelSubscriptionsMapping.Id;
        channelSubscriptionsMapping.Timestamp = channelSubscriptionsMappingDto.Timestamp;
        channelSubscriptionsMapping.Subscriber = channelSubscriptionsMappingDto.Subscriber?.ToChannelEntity();
        channelSubscriptionsMapping.Subscription = channelSubscriptionsMappingDto.Subscription?.ToChannelEntity();

        return channelSubscriptionsMapping;
    }

    public static ChannelSubscriptionsMappingDto ToChannelSubscriptionsMappingDto(this ChannelSubscriptionsMapping channelSubscriptionsMapping,
        bool includeSubscribers = true, bool includeSubscriptions = true)
    {
        ChannelSubscriptionsMappingDto channelSubscriptionsMappingDto = new ChannelSubscriptionsMappingDto();

        channelSubscriptionsMappingDto.Id = channelSubscriptionsMapping.Id;
        channelSubscriptionsMappingDto.Timestamp = channelSubscriptionsMapping.Timestamp;
        
        channelSubscriptionsMappingDto.Subscriber = includeSubscribers
            ? channelSubscriptionsMapping.Subscriber?.ToChannelDto(includeSubscribers: false, includeSubscriptions: false)
            : null;

        channelSubscriptionsMappingDto.Subscription = includeSubscriptions
            ? channelSubscriptionsMapping.Subscription?.ToChannelDto(includeSubscribers: false, includeSubscriptions: false)
            : null;

        return channelSubscriptionsMappingDto;
    }
}