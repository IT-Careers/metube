using MeTube.Data.Models.Reactions;
using MeTube.Data.Repository;
using MeTube.Service.Models;

namespace MeTube.Service;

public class VideoService : IVideoService
{
    private readonly VideoRepository _videoRepository;

    public VideoService(VideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }
    
    public async Task<VideoDto> GetById(string id)
    {
        return VideoDto.fromEntity(await _videoRepository.GetById(id));
    }

    public async Task<List<VideoDto>> GetAllPlaylistVideos(string playlistId)
    {
        return _videoRepository.GetAllByPlaylistId(playlistId)
            .Result.Select(e => VideoDto.fromEntity(e))
            .ToList();
    }

    public Task<VideoDto> Create(VideoDto attachmentDto)
    {
        throw new NotImplementedException();
    }

    public Task<VideoDto> Edit(VideoDto attachmentDto)
    {
        throw new NotImplementedException();
    }

    public Task<VideoDto> DeleteById(string id)
    {
        throw new NotImplementedException();
    }
}