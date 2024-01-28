using MeTube.Service.Models;

namespace MeTube.Service;

public interface IVideoService
{
    Task<VideoDto> GetByIdAsync(string id);

    IQueryable<VideoDto> GetAll();

    Task<ICollection<VideoDto>> GetAllPlaylistVideos(string playlistId);
    
    Task<VideoDto> CreateAsync(VideoDto videoDto);
    
    Task<VideoDto> EditAsync(VideoDto attachmentDto);
    
    Task<VideoDto> DeleteByIdAsync(string id);
}