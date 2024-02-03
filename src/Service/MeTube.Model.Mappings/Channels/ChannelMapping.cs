using MeTube.Data.Models.Channels;
using MeTube.Service.Models.Channels;

namespace MeTube.Model.Mappings.Channels;

public static class ChannelMapping
{
    public static Channel ToEntity(this ChannelDto channelDto)
    {
        Channel channel = new Channel();

        return channel;
    }

    public static ChannelDto ToDto(this Channel channel)
    {
        ChannelDto channelDto = new ChannelDto();

        return channelDto;
    }
}
