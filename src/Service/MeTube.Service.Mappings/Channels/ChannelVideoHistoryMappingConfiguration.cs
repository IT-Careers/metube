using MeTube.Data.Models.Channels;
using MeTube.Service.Mappings.Videos;
using MeTube.Service.Models.Channels;

namespace MeTube.Service.Mappings.Channels;

public static class ChannelVideoHistoryMappingConfiguration
{
    public static ChannelVideoHistoryMapping ToChannelVideoHistoryMappingEntity(this ChannelVideoHistoryMappingDto channelVideoHistoryMappingDto)
    {
        ChannelVideoHistoryMapping channelVideoHistoryMapping = new ChannelVideoHistoryMapping();

        channelVideoHistoryMapping.Id = channelVideoHistoryMappingDto.Id ?? channelVideoHistoryMapping.Id;
        channelVideoHistoryMapping.Timestamp = channelVideoHistoryMappingDto.Timestamp;
        channelVideoHistoryMapping.Video = channelVideoHistoryMappingDto.Video?.ToVideoEntity();
        channelVideoHistoryMapping.Channel = channelVideoHistoryMappingDto.Channel?.ToChannelEntity();

        return channelVideoHistoryMapping;
    }

    public static ChannelVideoHistoryMappingDto ToChannelVideoHistoryMappingDto(this ChannelVideoHistoryMapping channelVideoHistoryMapping,
        bool includeChannel = true)
    {
        ChannelVideoHistoryMappingDto channelVideoHistoryMappingDto = new ChannelVideoHistoryMappingDto();

        channelVideoHistoryMappingDto.Id = channelVideoHistoryMapping.Id;
        channelVideoHistoryMappingDto.Timestamp = channelVideoHistoryMapping.Timestamp;
        channelVideoHistoryMappingDto.Video = channelVideoHistoryMapping.Video?.ToVideoDto();

        channelVideoHistoryMappingDto.Channel = includeChannel
            ? channelVideoHistoryMapping.Channel?.ToChannelDto(includeHistory: false)
            : null;

        return channelVideoHistoryMappingDto;
    }
}