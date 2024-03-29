﻿using MeTube.Service.Models.Comments;
using MeTube.Service.Models.Playlist;
using MeTube.Service.Models.Reactions;
using MeTube.Service.Models.Videos;

namespace MeTube.Service.Models.Channels;

public class ChannelDto : BaseEntityDto
{
    public ChannelDto()
    {
        Subscribers = new List<ChannelSubscriptionsMappingDto>();
        Subscriptions = new List<ChannelSubscriptionsMappingDto>();
        Videos = new List<VideoDto>();
        Playlists = new List<PlaylistDto>();
        VideoReactions = new List<VideoReactionDto>();
        VideoComments = new List<VideoCommentDto>();
        PlaylistReactions = new List<PlaylistReactionDto>();
        PlaylistComments = new List<PlaylistCommentDto>();
        History = new List<ChannelVideoHistoryMappingDto>();
    }

    public string Name { get; set; }

    public MeTubeUserDto User { get; set; }

    public List<ChannelSubscriptionsMappingDto> Subscribers { get; set; }

    public List<ChannelSubscriptionsMappingDto> Subscriptions { get; set; }

    public List<VideoDto> Videos { get; set; }

    public List<PlaylistDto> Playlists { get; set; }

    public List<VideoReactionDto> VideoReactions { get; set; }

    public List<VideoCommentDto> VideoComments { get; set; }

    public List<PlaylistReactionDto> PlaylistReactions { get; set; }

    public List<PlaylistCommentDto> PlaylistComments { get; set; }

    public List<ChannelVideoHistoryMappingDto> History { get; set; }

    public AttachmentDto ProfilePicture { get; set; }

    public AttachmentDto CoverPicture { get; set; }

    public string About { get; set; }
}
