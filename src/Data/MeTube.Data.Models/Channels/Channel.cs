using MeTube.Data.Models.Comments;
using MeTube.Data.Models.Playlists;
using MeTube.Data.Models.Reactions;
using MeTube.Data.Models.Videos;

namespace MeTube.Data.Models.Channels;

public class Channel : BaseEntity
{
    public string Name { get; set; }

    public MeTubeUser User { get; set; }
    
    public List<ChannelSubscriptionsMapping> Subscribers { get; set; }

    public List<ChannelSubscriptionsMapping> Subscriptions { get; set; }

    public List<Video> Videos { get; set; }

    public List<Playlist> Playlists { get; set; }

    public List<VideoReaction> VideoReactions { get; set; }

    public List<VideoComment> VideoComments { get; set; }

    public List<PlaylistReaction> PlaylistReactions { get; set; }

    public List<PlaylistComment> PlaylistComments { get; set; }

    public List<ChannelVideoHistoryMapping> History { get; set; }

    public Attachment? ProfilePicture { get; set; }

    public Attachment? CoverPicture { get; set; }

    public string About { get; set; }
}
