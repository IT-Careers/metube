using MeTube.Service.Models.Videos;

namespace MeTube.Service.Videos;

public interface IVideoService
{
    Task<VideoDto> GetByIdAsync(string id);

    Task<VideoDto> ViewVideoByIdAsync(string videoId);

    IQueryable<VideoDto> GetAll();

    Task<ICollection<VideoDto>> GetAllPlaylistVideos(string playlistId);

    Task<VideoDto> CreateAsync(VideoDto videoDto, string userId);

    Task<VideoDto> EditAsync(VideoDto attachmentDto);

    Task<VideoDto> DeleteByIdAsync(string id);
}