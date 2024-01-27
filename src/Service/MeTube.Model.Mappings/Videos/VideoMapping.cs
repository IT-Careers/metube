using MeTube.Data.Models.Videos;
using MeTube.Model.Mappings.Comments;
using MeTube.Model.Mappings.Reactions;
using MeTube.Service.Models;

namespace MeTube.Model.Mappings.Videos;

public static class VideoMapping
{
    public static Video ToEntity(this VideoDto videoDto)
    {
        Video video = new Video();

        video.Id = videoDto.Id;
        video.Title = videoDto.Title;
        video.Description = videoDto.Description;
        video.VideoFile = videoDto.VideoFile.ToEntity();
        video.ThumbnailImage = videoDto.ThumbnailImage.ToEntity();
        video.Comments = videoDto.Comments.Select(vcDto => vcDto.ToEntity()).ToList();
        video.Reactions = videoDto.Reactions.Select(vcr => vcr.ToEntity()).ToList();

        return video;
    }

    public static VideoDto ToDto(this Video video)
    {
        VideoDto videoDto = new VideoDto();

        videoDto.Id = video.Id;
        videoDto.Title = video.Title;
        videoDto.Description = video.Description;
        videoDto.VideoFile = video.VideoFile.ToDto();
        videoDto.ThumbnailImage = video.ThumbnailImage.ToDto();
        videoDto.Comments = video.Comments.Select(vc => vc.ToDto()).ToList();
        videoDto.Reactions = video.Reactions.Select(vcr => vcr.ToDto()).ToList();

        return videoDto;
    }
}