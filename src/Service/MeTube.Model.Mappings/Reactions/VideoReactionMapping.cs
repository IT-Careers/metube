using MeTube.Data.Models.Reactions;
using MeTube.Model.Mappings.Channels;
using MeTube.Model.Mappings.Videos;
using MeTube.Service.Models.Reactions;

namespace MeTube.Model.Mappings.Reactions;

public static class VideoReactionMapping
{
    public static VideoReaction ToEntity(this VideoReactionDto videoReactionDto)
    {
        VideoReaction videoReaction = new VideoReaction();

        videoReaction.Id = videoReactionDto.Id;
        videoReaction.Channel = videoReactionDto.Channel.ToEntity();
        videoReaction.Type = videoReactionDto.Type.ToEntity();

        return videoReaction;
    }

    public static VideoReactionDto ToDto(this VideoReaction videoReaction, bool includeVideo = true,
        bool includeChannel = true)
    {
        VideoReactionDto videoReactionDto = new VideoReactionDto();

        videoReactionDto.Id = videoReaction.Id;
        videoReactionDto.Type = videoReaction.Type.ToDto();

        videoReactionDto.Video = includeVideo
            ? videoReaction.Video.ToDto(includeReactions: false)
            : null;

        videoReactionDto.Channel = includeChannel
            ? videoReaction.Channel.ToDto(includeVideoReactions: false)
            : null;
        
        return videoReactionDto;
    }
}