using MeTube.Data.Models.Comments;
using MeTube.Data.Repository.Comments;
using MeTube.Model.Mappings.Comments;
using MeTube.Service.Models.Comments;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service.Comments;

public class VideoCommentService : IVideoCommentService
{
    private readonly VideoCommentRepository _videoCommentRepository;

    public VideoCommentService(VideoCommentRepository videoCommentRepository)
    {
        _videoCommentRepository = videoCommentRepository;
    }

    public async Task<VideoCommentDto> CreateAsync(VideoCommentDto videoCommentDto)
    {
        VideoComment videoComment = videoCommentDto.ToEntity();

        return (await _videoCommentRepository.CreateAsync(videoComment)).ToDto();
    }

    public async Task<VideoCommentDto> DeleteByIdAsync(string id)
    {
        VideoComment videoComment = await GetByIdInternalAsync(id);

        return (await _videoCommentRepository.DeleteAsync(videoComment)).ToDto();
    }

    public async Task<VideoCommentDto> EditAsync(VideoCommentDto videoCommentDto)
    {
        VideoComment videoComment = videoCommentDto.ToEntity();

        return (await _videoCommentRepository.EditAsync(videoComment)).ToDto();
    }

    public IQueryable<VideoCommentDto> GetAll()
    {
        return _videoCommentRepository.GetAllAsNoTracking().Select(videoComment => videoComment.ToDto());
    }

    public async Task<VideoCommentDto> GetByIdAsync(string id)
    {
        return (await GetByIdInternalAsync(id)).ToDto();
    }

    private async Task<VideoComment> GetByIdInternalAsync(string id)
    {
        return await _videoCommentRepository.GetAll()
            .SingleOrDefaultAsync(videoComment => videoComment.Id == id);
    }
}
