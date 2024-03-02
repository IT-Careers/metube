using MeTube.Data.Models.Comments;
using MeTube.Data.Repository.Comments;
using MeTube.Service.Mappings.Comments;
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
        VideoComment videoComment = videoCommentDto.ToVideoCommentEntity();

        return (await _videoCommentRepository.CreateAsync(videoComment)).ToVideoCommentDto();
    }

    public async Task<VideoCommentDto> DeleteByIdAsync(string id)
    {
        VideoComment videoComment = await GetByIdInternalAsync(id);

        return (await _videoCommentRepository.DeleteAsync(videoComment)).ToVideoCommentDto();
    }

    public async Task<VideoCommentDto> EditAsync(VideoCommentDto videoCommentDto)
    {
        VideoComment videoComment = videoCommentDto.ToVideoCommentEntity();

        return (await _videoCommentRepository.EditAsync(videoComment)).ToVideoCommentDto();
    }

    public IQueryable<VideoCommentDto> GetAll()
    {
        return _videoCommentRepository.GetAllAsNoTracking()
            .Select(videoComment => videoComment.ToVideoCommentDto(true, true, true));
    }

    public async Task<VideoCommentDto> GetByIdAsync(string id)
    {
        return (await GetByIdInternalAsync(id)).ToVideoCommentDto();
    }

    private async Task<VideoComment> GetByIdInternalAsync(string id)
    {
        return await _videoCommentRepository.GetAll()
            .SingleOrDefaultAsync(videoComment => videoComment.Id == id);
    }
}