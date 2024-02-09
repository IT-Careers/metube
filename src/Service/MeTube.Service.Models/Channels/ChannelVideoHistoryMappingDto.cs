using MeTube.Service.Models.Videos;

namespace MeTube.Service.Models.Channels;

public class ChannelVideoHistoryMappingDto : BaseEntityDto
{
    public long Timestamp { get; set; }

    public VideoDto Video { get; set; }

    public ChannelDto Channel { get; set; }
}
