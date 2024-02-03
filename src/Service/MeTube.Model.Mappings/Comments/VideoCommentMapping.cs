using MeTube.Data.Models.Comments;
using MeTube.Model.Mappings.Channels;
using MeTube.Service.Models.Comments;

namespace MeTube.Model.Mappings.Comments;

public static class VideoCommentMapping
{
    public static VideoComment ToEntity(this VideoCommentDto videoCommentDto)
    {
        VideoComment videoComment = new VideoComment();

        videoComment.Id = videoCommentDto.Id;
        videoComment.Content = videoCommentDto.Content;
        videoComment.CreatedBy = videoCommentDto.CreatedBy.ToEntity();
        videoComment.Replies = videoCommentDto.Replies.Select(vcrDto => vcrDto.ToEntity()).ToList();

        return videoComment;
    }

    public static VideoCommentDto ToDto(this VideoComment videoComment)
    {
        VideoCommentDto videoCommentDto = new VideoCommentDto();

        videoCommentDto.Id = videoComment.Id;
        videoCommentDto.Content = videoComment.Content;
        videoCommentDto.CreatedBy = videoComment.CreatedBy.ToDto();
        videoCommentDto.Replies = videoComment.Replies.Select(vcr => vcr.ToDto()).ToList();

        return videoCommentDto;
    }
}
