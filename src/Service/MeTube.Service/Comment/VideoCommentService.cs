using MeTube.Data.Models.Comments;
using MeTube.Data.Repository;
using MeTube.Model.Mappings.Comments;
using MeTube.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service.Comment;

public class VideoCommentService : IVideoCommentService
{
    private readonly VideoCommentRepository _videoCommentRepository;

    public VideoCommentService(VideoCommentRepository videoCommentRepository)
    {
        this._videoCommentRepository = videoCommentRepository;
    }

    public async Task<VideoCommentDto> CreateAsync(VideoCommentDto videoCommentDto)
    {
        VideoComment videoComment = videoCommentDto.ToEntity();

        return (await this._videoCommentRepository.CreateAsync(videoComment)).ToDto();
    }

    public async Task<VideoCommentDto> DeleteByIdAsync(string id)
    {
        VideoComment videoComment = await this.GetByIdInternalAsync(id);

        return (await this._videoCommentRepository.DeleteAsync(videoComment)).ToDto();
    }

    public async Task<VideoCommentDto> EditAsync(VideoCommentDto videoCommentDto)
    {
        VideoComment videoComment = videoCommentDto.ToEntity();

        return (await this._videoCommentRepository.EditAsync(videoComment)).ToDto();
    }

    public IQueryable<VideoCommentDto> GetAll()
    {
        return this._videoCommentRepository.GetAllAsNoTracking().Select(videoComment => videoComment.ToDto());
    }

    public async Task<VideoCommentDto> GetByIdAsync(string id)
    {
        return (await this.GetByIdInternalAsync(id)).ToDto();
    }

    private async Task<VideoComment> GetByIdInternalAsync(string id)
    {
        return await this._videoCommentRepository.GetAll()
            .SingleOrDefaultAsync(videoComment => videoComment.Id == id);
    }
}
