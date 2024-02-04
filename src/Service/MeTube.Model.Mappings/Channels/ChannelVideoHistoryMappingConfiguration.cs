using MeTube.Data.Models.Channels;
using MeTube.Model.Mappings.Videos;
using MeTube.Service.Models.Channels;

namespace MeTube.Model.Mappings.Channels;

public static class ChannelVideoHistoryMappingConfiguration
{
    public static ChannelVideoHistoryMapping ToEntity(this ChannelVideoHistoryMappingDto channelVideoHistoryMappingDto) 
    {
        ChannelVideoHistoryMapping channelVideoHistoryMapping = new ChannelVideoHistoryMapping();

        channelVideoHistoryMapping.Id = channelVideoHistoryMappingDto.Id ?? channelVideoHistoryMapping.Id;
        channelVideoHistoryMapping.Timestamp = channelVideoHistoryMappingDto.Timestamp;
        channelVideoHistoryMapping.Video = channelVideoHistoryMappingDto.Video.ToEntity();
        channelVideoHistoryMapping.Channel = channelVideoHistoryMappingDto.Channel.ToEntity();

        return channelVideoHistoryMapping;
    }

    public static ChannelVideoHistoryMappingDto ToDto(this ChannelVideoHistoryMapping channelVideoHistoryMapping)
    {
        ChannelVideoHistoryMappingDto channelVideoHistoryMappingDto = new ChannelVideoHistoryMappingDto();

        channelVideoHistoryMappingDto.Id = channelVideoHistoryMapping.Id;
        channelVideoHistoryMappingDto.Timestamp = channelVideoHistoryMapping.Timestamp;
        channelVideoHistoryMappingDto.Video = channelVideoHistoryMapping.Video.ToDto();
        channelVideoHistoryMappingDto.Channel = channelVideoHistoryMapping.Channel.ToDto();

        return channelVideoHistoryMappingDto;
    }
}
