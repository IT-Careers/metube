using MeTube.Data.Models.Reactions;
using MeTube.Service.Models.Reactions;

namespace MeTube.Model.Mappings.Reactions;

public static class VideoReactionMapping
{
    public static VideoReaction ToEntity(this VideoReactionDto videoReactionDto)
    {
        VideoReaction videoReaction = new VideoReaction();

        videoReaction.Id = videoReactionDto.Id;
        videoReaction.User = videoReactionDto.User.ToEntity();
        videoReaction.Type = videoReactionDto.Type.ToEntity();

        return videoReaction;
    }

    public static VideoReactionDto ToDto(this VideoReaction videoReaction)
    {
        VideoReactionDto videoReactionDto = new VideoReactionDto();

        videoReactionDto.Id = videoReaction.Id;
        videoReactionDto.User = videoReaction.User.ToDto();
        videoReactionDto.Type = videoReaction.Type.ToDto();

        return videoReactionDto;
    }
}
