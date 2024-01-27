using MeTube.Data.Models.Videos;
using MeTube.Data.Repository;
using MeTube.Model.Mappings.Videos;
using MeTube.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service;

public class VideoService : IVideoService
{
    private readonly VideoRepository _videoRepository;

    private readonly IPlaylistService _playlistService;

    public VideoService(VideoRepository videoRepository, IPlaylistService playlistService)
    {
        this._videoRepository = videoRepository;
        this._playlistService = playlistService;
    }

    public async Task<VideoDto> GetByIdAsync(string id)
    {
        return (await this.GetByIdInternalAsync(id)).ToDto();
    }

    public IQueryable<VideoDto> GetAll()
    {
        return this._videoRepository.GetAllAsNoTracking().Select(video => video.ToDto());
    }

    public async Task<ICollection<VideoDto>> GetAllPlaylistVideos(string playlistId)
    {
        return (await this._playlistService.GetByIdAsync(playlistId)).Videos;
    }

    public async Task<VideoDto> CreateAsync(VideoDto videoDto)
    {
        Video video = videoDto.ToEntity();

        return (await _videoRepository.CreateAsync(video)).ToDto();
    }

    public async Task<VideoDto> EditAsync(VideoDto videoDto)
    {
        Video video = videoDto.ToEntity();

        return (await _videoRepository.EditAsync(video)).ToDto();
    }

    public async Task<VideoDto> DeleteByIdAsync(string id)
    {
        Video video = await this.GetByIdInternalAsync(id);

        return (await _videoRepository.DeleteAsync(video)).ToDto();
    }

    private async Task<Video> GetByIdInternalAsync(string id)
    {
        return await this._videoRepository.GetAll()
            .SingleOrDefaultAsync(video => video.Id == id);
    }
}