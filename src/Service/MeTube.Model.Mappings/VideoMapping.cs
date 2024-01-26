using MeTube.Data.Models.Comments;
using MeTube.Data.Models.Reactions;
using MeTube.Data.Models.Videos;
using MeTube.Service.Models;
using MeTube.Service.Models.Reactions;

namespace MeTube.Model.Mappings;

public static class VideoMapping
{
    public static Video ToEntity(VideoDto dto)
    {
        Video entity = new Video();

        entity.Title = dto.Title;
        entity.Description = dto.Description;
        entity.VideoFile = AttachmentMapping.ToEntity(dto.VideoFile);
        entity.ThumbnailImage = AttachmentMapping.ToEntity(dto.ThumbnailImage);
        //TODO use VideoComment Mapping
        entity.Comments = new List<VideoComment>(); 
        //TODO use VideoReaction Mapping
        entity.Reactions = new List<VideoReaction>();

        return entity;
    }

    public static VideoDto ToDto(Video entity)
    {
        VideoDto dto = new VideoDto();

        dto.Title = entity.Title;
        dto.Description = entity.Description;
        dto.VideoFile = AttachmentMapping.ToDto(entity.VideoFile);
        dto.ThumbnailImage = AttachmentMapping.ToDto(entity.ThumbnailImage);
        //TODO use VideoComment Mapping
        dto.Comments = new List<VideoCommentDto>(); 
        //TODO use VideoReaction Mapping
        dto.Reactions = new List<VideoReactionDto>();

        return dto;
    }
}