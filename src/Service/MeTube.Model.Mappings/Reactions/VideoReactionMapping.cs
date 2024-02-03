using MeTube.Data.Models.Reactions;
using MeTube.Model.Mappings.Channels;
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

    public static VideoReactionDto ToDto(this VideoReaction videoReaction)
    {
        VideoReactionDto videoReactionDto = new VideoReactionDto();

        videoReactionDto.Id = videoReaction.Id;
        videoReactionDto.Channel = videoReaction.Channel.ToDto();
        videoReactionDto.Type = videoReaction.Type.ToDto();

        return videoReactionDto;
    }
}
