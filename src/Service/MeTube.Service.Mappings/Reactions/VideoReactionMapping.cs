using MeTube.Data.Models.Reactions;
using MeTube.Service.Mappings.Channels;
using MeTube.Service.Mappings.Videos;
using MeTube.Service.Models.Reactions;

namespace MeTube.Service.Mappings.Reactions;

public static class VideoReactionMapping
{
    public static VideoReaction ToVideoReactionEntity(this VideoReactionDto videoReactionDto)
    {
        VideoReaction videoReaction = new VideoReaction();

        videoReaction.Id = videoReactionDto.Id;
        videoReaction.Channel = videoReactionDto.Channel?.ToChannelEntity();
        videoReaction.Type = videoReactionDto.Type?.ToReactionTypeEntity();

        return videoReaction;
    }

    public static VideoReactionDto ToVideoReactionDto(this VideoReaction videoReaction, bool includeVideo = true,
        bool includeChannel = true)
    {
        VideoReactionDto videoReactionDto = new VideoReactionDto();

        videoReactionDto.Id = videoReaction.Id;
        videoReactionDto.Type = videoReaction.Type?.ToReactionTypeDto();

        videoReactionDto.Video = includeVideo
            ? videoReaction.Video?.ToVideoDto(includeReactions: false)
            : null;

        videoReactionDto.Channel = includeChannel
            ? videoReaction.Channel?.ToChannelDto(includeVideoReactions: false)
            : null;
        
        return videoReactionDto;
    }
}