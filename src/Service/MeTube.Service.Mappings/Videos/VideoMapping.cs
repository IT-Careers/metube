using MeTube.Data.Models.Videos;
using MeTube.Service.Mappings.Channels;
using MeTube.Service.Mappings.Comments;
using MeTube.Service.Mappings.Reactions;
using MeTube.Service.Models.Videos;

namespace MeTube.Service.Mappings.Videos;

public static class VideoMapping
{
    public static Video ToVideoEntity(this VideoDto videoDto)
    {
        Video video = new Video();

        video.Id = videoDto.Id ?? video.Id;
        video.Title = videoDto.Title;
        video.Description = videoDto.Description;
        video.Views = videoDto.Views;
        video.VideoFile = videoDto.VideoFile?.ToAttachmentEntity();
        video.Thumbnail = videoDto.Thumbnail?.ToAttachmentEntity();
        video.Comments = videoDto.Comments?.Select(vcDto => vcDto.ToVideoCommentEntity()).ToList();
        video.Reactions = videoDto.Reactions?.Select(vcr => vcr.ToVideoReactionEntity()).ToList();
        video.CreatedBy = videoDto.CreatedBy?.ToChannelEntity();
        video.UpdatedBy = videoDto.UpdatedBy?.ToChannelEntity();
        video.DeletedBy = videoDto.DeletedBy?.ToChannelEntity();

        return video;
    }

    public static VideoDto ToVideoDto(this Video video, bool includeComments = true, bool includeReactions = true, bool includeChannel = true)
    {
        VideoDto videoDto = new VideoDto();

        videoDto.Id = video.Id;
        videoDto.Title = video.Title;
        videoDto.Description = video.Description;
        videoDto.Views = video.Views;
        videoDto.VideoFile = video.VideoFile?.ToAttachmentDto();
        videoDto.Thumbnail = video.Thumbnail?.ToAttachmentDto();

        videoDto.Comments = includeComments
            ? video.Comments?.Select(vc => vc.ToVideoCommentDto(includeVideo: false)).ToList()
            : null;

        videoDto.Reactions = includeReactions
            ? video.Reactions?.Select(vcr => vcr.ToVideoReactionDto(includeVideo: false, includeChannel: false)).ToList()
            : null;

        videoDto.CreatedBy = includeChannel
            ? video.CreatedBy?.ToChannelDto(includeVideo: false, includeVideoReactions: false, includeVideoComments: false)
            : null;

        return videoDto;
    }
}