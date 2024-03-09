using MeTube.Service.Models.Videos;

namespace MeTube.Service.Models.Playlist;

public class PlaylistVideoMappingDto : BaseEntityDto
{

    public long Timestamp { get; set; }

    public PlaylistDto Playlist { get; set; }

    public VideoDto Video { get; set; }
}
