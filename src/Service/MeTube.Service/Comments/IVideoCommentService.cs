using MeTube.Service.Models.Comments;

namespace MeTube.Service.Comments;

public interface IVideoCommentService
{
    Task<VideoCommentDto> GetByIdAsync(string id);

    IQueryable<VideoCommentDto> GetAll();

    Task<VideoCommentDto> CreateAsync(VideoCommentDto videoCommentDto);

    Task<VideoCommentDto> EditAsync(VideoCommentDto videoCommentDto);

    Task<VideoCommentDto> DeleteByIdAsync(string id);
}