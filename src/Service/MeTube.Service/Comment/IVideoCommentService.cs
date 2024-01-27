using MeTube.Service.Models;

namespace MeTube.Service.Comment;

public interface IVideoCommentService
{
    Task<VideoCommentDto> GetByIdAsync(string id);

    IQueryable<VideoCommentDto> GetAll();

    Task<VideoCommentDto> CreateAsync(VideoCommentDto videoCommentDto);

    Task<VideoCommentDto> EditAsync(VideoCommentDto videoCommentDto);

    Task<VideoCommentDto> DeleteByIdAsync(string id);
}