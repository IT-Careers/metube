using MeTube.Data.Models.Videos;

namespace MeTube.Data.Repository.Videos;

public class VideoRepository : MetadataBaseRepository<Video>, IVideoRepository
{
    public VideoRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }

    //public async Task<List<Video>> GetAllByPlaylistId(string id)
    //{
    //    Playlist playlist = await _dbContext.Playlists
    //         .Include(e => e.Videos)
    //         .FirstAsync(p => p.Id == id);

    //    return playlist.Videos;
    //}
}