using MeTube.Service.Models.Channels;

namespace MeTube.Service.Models;

public class MetadataBaseEntityDto : BaseEntityDto
{
    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    public DateTime DeletedOn { get; set; }

    public ChannelDto? CreatedBy { get; set; }

    public ChannelDto? UpdatedBy { get; set; }

    public ChannelDto? DeletedBy { get; set; }
}
