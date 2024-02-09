using MeTube.Data.Models.Videos;

namespace MeTube.Data.Models.Channels;

public class ChannelVideoHistoryMapping : BaseEntity
{
    public long Timestamp { get; set; }

    public Video Video { get; set; }

    public Channel Channel { get; set; }
}
