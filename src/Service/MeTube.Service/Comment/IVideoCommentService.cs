using MeTube.Service.Models;

namespace MeTube.Service.Comment;

public interface IVideoCommentService
{
    Task<VideoCommentDto> GetById(string id);
    Task<VideoCommentDto> Create(VideoCommentDto attachmentDto);
    Task<VideoCommentDto> Edit(VideoCommentDto attachmentDto);
    Task<VideoCommentDto> DeleteById(string id);
}