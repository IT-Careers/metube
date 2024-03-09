using MeTube.Service.Models.Videos;

namespace MeTube.Service.Videos;

public interface IVideoService
{
    Task<VideoDto> GetByIdAsync(string id);

    Task<VideoDto> ViewVideoByIdAsync(string videoId);

    IQueryable<VideoDto> GetAll();

    Task<ICollection<VideoDto>> GetAllPlaylistVideos(string playlistId);

    IQueryable<VideoDto> GetSubscriptionVideos(string channelId, int count = 10);

    IQueryable<VideoDto> GetRandomVideos(HashSet<string> excludedVideoIds);

    Task<VideoDto> CreateAsync(VideoDto videoDto, string userId);

    Task<VideoDto> EditAsync(VideoDto attachmentDto);

    Task<VideoDto> DeleteByIdAsync(string id);
    
    Task<VideoDto> React(string videoId, string reactionTypeId, string userId);

    Task<VideoDto> Comment(string videoId, string content, string userId);
}