using MeTube.Data.Models.Comments;
using MeTube.Service.Models;

namespace MeTube.Model.Mappings.Comments;

public static class VideoCommentMapping
{
    public static VideoComment ToEntity(this VideoCommentDto videoCommentDto)
    {
        VideoComment videoComment = new VideoComment();

        videoComment.Id = videoCommentDto.Id;
        videoComment.Content = videoCommentDto.Content;
        videoComment.Poster = videoCommentDto.Poster.ToEntity();
        videoComment.Replies = videoCommentDto.Replies.Select(vcrDto => vcrDto.ToEntity()).ToList();

        return videoComment;
    }

    public static VideoCommentDto ToDto(this VideoComment videoComment)
    {
        VideoCommentDto videoCommentDto = new VideoCommentDto();

        videoCommentDto.Id = videoComment.Id;
        videoCommentDto.Content = videoComment.Content;
        videoCommentDto.Poster = videoComment.Poster.ToDto();
        videoCommentDto.Replies = videoComment.Replies.Select(vcr => vcr.ToDto()).ToList();

        return videoCommentDto;
    }
}
