using MeTube.Data.Models.Channels;
using MeTube.Service.Mappings.Comments;
using MeTube.Service.Mappings.Playlists;
using MeTube.Service.Mappings.Reactions;
using MeTube.Service.Mappings.Videos;
using MeTube.Service.Models.Channels;

namespace MeTube.Service.Mappings.Channels;

public static class ChannelMapping
{
    public static Channel ToChannelEntity(this ChannelDto channelDto)
    {
        Channel channel = new Channel();

        channel.Id = channelDto.Id ?? channel.Id;
        channel.Name = channelDto.Name;
        channel.About = channelDto.About;
        channel.ProfilePicture = channelDto.ProfilePicture?.ToAttachmentEntity();
        channel.CoverPicture = channelDto.CoverPicture?.ToAttachmentEntity();
        channel.User = channelDto.User?.ToMeTubeUserEntity();
        channel.Subscribers = channelDto.Subscribers?.Select(subscriber => subscriber.ToChannelSubscriptionsMappingEntity()).ToList();
        channel.Subscriptions = channelDto.Subscriptions?.Select(subscription => subscription.ToChannelSubscriptionsMappingEntity()).ToList();
        channel.Videos = channelDto.Videos?.Select(video => video.ToVideoEntity()).ToList();
        channel.Playlists = channelDto.Playlists?.Select(playlist => playlist.ToPlaylistEntity()).ToList();
        channel.VideoReactions = channelDto.VideoReactions?.Select(videoReaction => videoReaction.ToVideoReactionEntity()).ToList();
        channel.VideoComments = channelDto.VideoComments?.Select(videoComment => videoComment.ToVideoCommentEntity()).ToList();
        channel.PlaylistReactions = channelDto.PlaylistReactions
            ?.Select(playlistReaction => playlistReaction.ToPlaylistReactionEntity()).ToList();
        channel.PlaylistComments =
            channelDto.PlaylistComments?.Select(playlistComment => playlistComment.ToPlaylistCommentEntity()).ToList();
        channel.History = channelDto.History?.Select(history => history.ToChannelVideoHistoryMappingEntity()).ToList();

        return channel;
    }

    public static ChannelDto ToChannelDto(this Channel channel,
        bool includeVideoComments = true,
        bool includeVideo = true, 
        bool includePlaylist = true, 
        bool includeVideoReactions = true,
        bool includePlaylistReactions = true,
        bool includeHistory = true,
        bool includePlaylistComments = true, 
        bool includeSubscribers = true, 
        bool includeSubscriptions = true)
    {
        ChannelDto channelDto = new ChannelDto();

        channelDto.Id = channel.Id;
        channelDto.Name = channel.Name;
        channelDto.About = channel.About;
        channelDto.ProfilePicture = channel.ProfilePicture?.ToAttachmentDto();
        channelDto.CoverPicture = channel.CoverPicture?.ToAttachmentDto();
        channelDto.User = channel.User?.ToMeTubeUserDto();

        channelDto.Videos = includeVideo
            ? channel.Videos?.Select(video => video.ToVideoDto(includeChannel: false)).ToList() 
            : null;

        channelDto.Playlists = includePlaylist
            ? channel.Playlists?.Select(playlist => playlist.ToPlaylistDto()).ToList()
            : null;

        channelDto.VideoReactions = includeVideoReactions
            ? channel.VideoReactions?.Select(videoReaction => videoReaction.ToVideoReactionDto(includeChannel: false, includeVideo: includeVideo)).ToList()
            : null;

        channelDto.PlaylistReactions = includePlaylistReactions
            ? channel.PlaylistReactions?.Select(playlistReaction => playlistReaction.ToPlaylistReactionDto(includeChannel: false)).ToList()
            : null;

        channelDto.History = includeHistory
            ? channel.History?.Select(history => history.ToChannelVideoHistoryMappingDto(includeChannel: false)).ToList()
            : null;

        channelDto.VideoComments = includeVideoComments
            ? channel.VideoComments?.Select(videoComment => videoComment.ToVideoCommentDto(includeChannel: false, includeVideo: includeVideo)).ToList()
            : null;
        
        channelDto.Subscribers = includeSubscribers
            ? channel.Subscribers?.Select(subscriber => subscriber.ToChannelSubscriptionsMappingDto(includeSubscriptions: false, includeVideo: includeVideo)).ToList()
            : null;
        
        channelDto.Subscriptions = includeSubscriptions
            ? channel.Subscriptions?.Select(subscription => subscription.ToChannelSubscriptionsMappingDto(includeSubscribers: false, includeVideo: includeVideo)).ToList()
            : null;
        
        channelDto.PlaylistComments = includePlaylistComments
            ? channel.PlaylistComments?.Select(playlistComment => playlistComment.ToPlaylistCommentDto(includeChannel: false)).ToList()
            : null;
        
        return channelDto;
    }
}