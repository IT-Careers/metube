using MeTube.Service.Models.Playlist;
using MeTube.Service.Models.Videos;

namespace MeTube.Service.Models.Channels;

public class ChannelDto : BaseEntityDto
{
    public MeTubeUserDto User { get; set; }

    public List<ChannelDto> Subscribers { get; set; }

    public List<ChannelDto> Subscriptions { get; set; }

    public List<VideoDto> Videos { get; set; }

    public List<PlaylistDto> Playlists { get; set; }

    public List<VideoDto> ReactedVideos { get; set; }

    public List<VideoDto> CommentedVideos { get; set; }

    public List<PlaylistDto> ReactedPlaylists { get; set; }

    public List<PlaylistDto> CommentedPlaylists { get; set; }

    public List<VideoDto> History { get; set; }

    public AttachmentDto ProfilePicture { get; set; }

    public AttachmentDto CoverPicture { get; set; }

    public string About { get; set; }
}
