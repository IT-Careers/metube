using MeTube.Data.Models.Channels;
using MeTube.Model.Mappings.Comments;
using MeTube.Model.Mappings.Playlists;
using MeTube.Model.Mappings.Reactions;
using MeTube.Model.Mappings.Videos;
using MeTube.Service.Models.Channels;

namespace MeTube.Model.Mappings.Channels;

public static class ChannelMapping
{
    public static Channel ToEntity(this ChannelDto channelDto)
    {
        Channel channel = new Channel();

        channel.Id = channelDto.Id ?? channel.Id;
        channel.Name = channelDto.Name;
        channel.About = channelDto.About;
        channel.ProfilePicture = channelDto.ProfilePicture?.ToEntity();
        channel.CoverPicture = channelDto.CoverPicture?.ToEntity();
        channel.User = channelDto.User?.ToEntity();
        channel.Subscribers = channelDto.Subscribers?.Select(subscriber => subscriber.ToEntity()).ToList();
        channel.Subscriptions = channelDto.Subscriptions?.Select(subscription => subscription.ToEntity()).ToList();
        channel.Videos = channelDto.Videos?.Select(video => video.ToEntity()).ToList();
        channel.Playlists = channelDto.Playlists?.Select(playlist => playlist.ToEntity()).ToList();
        channel.VideoReactions = channelDto.VideoReactions?.Select(videoReaction => videoReaction.ToEntity()).ToList();
        channel.VideoComments = channelDto.VideoComments?.Select(videoComment => videoComment.ToEntity()).ToList();
        channel.PlaylistReactions = channelDto.PlaylistReactions?.Select(playlistReaction => playlistReaction.ToEntity()).ToList();
        channel.PlaylistComments = channelDto.PlaylistComments?.Select(playlistComment => playlistComment.ToEntity()).ToList();
        channel.History = channelDto.History?.Select(history => history.ToEntity()).ToList();

        return channel;
    }

    public static ChannelDto ToDto(this Channel channel)
    {
        ChannelDto channelDto = new ChannelDto();

        channelDto.Id = channel.Id;
        channelDto.Name = channel.Name;
        channelDto.About = channel.About;
        channelDto.ProfilePicture = channel.ProfilePicture?.ToDto();
        channelDto.CoverPicture = channel.CoverPicture?.ToDto();
        channelDto.User = channel.User?.ToDto();
        channelDto.Subscribers = channel.Subscribers?.Select(subscriber => subscriber.ToDto()).ToList();
        channelDto.Subscriptions = channel.Subscriptions?.Select(subscription => subscription.ToDto()).ToList();
        channelDto.Videos = channel.Videos?.Select(video => video.ToDto()).ToList();
        channelDto.Playlists = channel.Playlists?.Select(playlist => playlist.ToDto()).ToList();
        channelDto.VideoReactions = channel.VideoReactions?.Select(videoReaction => videoReaction.ToDto()).ToList();
        channelDto.VideoComments = channel.VideoComments?.Select(videoComment => videoComment.ToDto()).ToList();
        channelDto.PlaylistReactions = channel.PlaylistReactions?.Select(playlistReaction => playlistReaction.ToDto()).ToList();
        channelDto.PlaylistComments = channel.PlaylistComments?.Select(playlistComment => playlistComment.ToDto()).ToList();
        channelDto.History = channel.History?.Select(history => history.ToDto()).ToList();

        return channelDto;
    }
}
