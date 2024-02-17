using MeTube.Data.Models.Comments;
using MeTube.Model.Mappings.Channels;
using MeTube.Model.Mappings.Reactions;
using MeTube.Model.Mappings.Videos;
using MeTube.Service.Models.Comments;
using Microsoft.EntityFrameworkCore.Query;

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

    public static VideoCommentDto ToDto(this VideoComment videoComment, bool includeVideo = true,
        bool includeChannel = true, bool includeReactions = true)
    {
        VideoCommentDto videoCommentDto = new VideoCommentDto();

        videoCommentDto.Id = videoComment.Id;
        videoCommentDto.Content = videoComment.Content;
        videoCommentDto.Replies = videoComment.Replies.Select(vcr => vcr.ToDto()).ToList();

        videoCommentDto.Video = includeVideo
            ? videoComment.Video.ToDto(includeComments: false)
            : null;

        videoCommentDto.CreatedBy = includeChannel
            ? videoComment.CreatedBy.ToDto(includeVideoComment: false)
            : null;

        videoCommentDto.Reactions = includeReactions
            ? videoComment.Reactions.Select(vcr => vcr.ToDto(includeComments: false)).ToList()
            : null;

        return videoCommentDto;
    }
}