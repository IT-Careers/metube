using MeTube.Data.Models.Comments;
using MeTube.Service.Mappings.Channels;
using MeTube.Service.Mappings.Reactions;
using MeTube.Service.Mappings.Videos;
using MeTube.Service.Models.Comments;

namespace MeTube.Service.Mappings.Comments;

public static class VideoCommentMapping
{
    public static VideoComment ToVideoCommentEntity(this VideoCommentDto videoCommentDto)
    {
        VideoComment videoComment = new VideoComment();

        videoComment.Id = videoCommentDto.Id;
        videoComment.Content = videoCommentDto.Content;
        videoComment.CreatedBy = videoCommentDto.CreatedBy?.ToChannelEntity();
        videoComment.Replies = videoCommentDto.Replies?.Select(vcrDto => vcrDto.ToVideoCommentEntity()).ToList();

        return videoComment;
    }

    public static VideoCommentDto ToVideoCommentDto(
        this VideoComment videoComment, 
        bool includeVideo = true,
        bool includeChannel = true, 
        bool includeReactions = true)
    {
        VideoCommentDto videoCommentDto = new VideoCommentDto();

        videoCommentDto.Id = videoComment.Id;
        videoCommentDto.Content = videoComment.Content;
        videoCommentDto.Replies = videoComment.Replies?.Select(vcr => vcr.ToVideoCommentDto()).ToList();

        videoCommentDto.Video = includeVideo
            ? videoComment.Video?.ToVideoDto(includeComments: false)
            : null;

        videoCommentDto.CreatedBy = includeChannel
            ? videoComment.CreatedBy?.ToChannelDto(
                includeVideo: false, 
                includeVideoComments: false, 
                includeVideoReactions: false, 
                includePlaylistReactions: false, 
                includePlaylistComments: false)
            : null;

        videoCommentDto.Reactions = includeReactions
            ? videoComment.Reactions?.Select(vcr => vcr.ToVideoCommentReactionDto(includeComments: false, includeChannel: false)).ToList()
            : null;

        return videoCommentDto;
    }
}