using MeTube.Data.Models.Videos;
using MeTube.Data.Repository;
using MeTube.Model.Mappings.Videos;
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
        return VideoMapping.ToDto(GetByIdInternal(id));
    }

    public async Task<List<VideoDto>> GetAllPlaylistVideos(string playlistId)
    {
        return _videoRepository.GetAllByPlaylistId(playlistId)
            .Result.Select(e => VideoMapping.ToDto(e))
            .ToList();
    }

    public async Task<VideoDto> Create(VideoDto videoDto)
    {
        Video video = VideoMapping.ToEntity(videoDto);

        return VideoMapping.ToDto(await _videoRepository.Create(video));
    }

    public async Task<VideoDto> Edit(VideoDto videoDto)
    {
        Video video = VideoMapping.ToEntity(videoDto);

        return VideoMapping.ToDto(await _videoRepository.Edit(video));
    }

    public async Task<VideoDto> DeleteById(string id)
    {
        Video video = GetByIdInternal(id);

        return VideoMapping.ToDto(await _videoRepository.Delete(video));
    }

    private Video GetByIdInternal(string id)
    {
        return _videoRepository.GetAll()
            .Result
            .First(video => video.Id == id);
    }
}