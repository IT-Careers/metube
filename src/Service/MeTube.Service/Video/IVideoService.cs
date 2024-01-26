using MeTube.Service.Models;

namespace MeTube.Service;

public interface IVideoService
{
    Task<VideoDto> GetById(string id);
    Task<List<VideoDto>> GetAllPlaylistVideos(string playlistId);
    Task<VideoDto> Create(VideoDto videoDto);
    Task<VideoDto> Edit(VideoDto attachmentDto);
    Task<VideoDto> DeleteById(string id);
}