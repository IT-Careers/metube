using MeTube.Service;
using MeTube.Service.Attachments;
using MeTube.Service.Models.Playlist;
using MeTube.Service.Models.Videos;
using MeTube.Service.Playlists;
using MeTube.Web.Models.Playlist;

namespace MeTube.Web.Utilities;

public class PlaylistFacade : IPlaylistFacade
{
    private readonly IPlaylistService _playlistService;

    private readonly ICloudinaryService _cloudinaryService;

    private readonly IAttachmentService _attachmentService;

    public PlaylistFacade(IPlaylistService playlistService, ICloudinaryService cloudinaryService, IAttachmentService attachmentService)
    {
        this._playlistService = playlistService;
        this._cloudinaryService = cloudinaryService;
        this._attachmentService = attachmentService;
    }


    public async Task CreatePlaylist(PlaylistCreateModel playlistCreateModel, string channelId)
    {
        var videoIds = playlistCreateModel.VideoIds.Split(",").Select(videoId => new PlaylistVideoMappingDto { Video = new VideoDto { Id = videoId } }).ToList();
        var thumbnailData = await this._cloudinaryService.UploadFile(playlistCreateModel.Thumbnail);

        await this._playlistService.CreateAsync(new PlaylistDto
        {
            Title = playlistCreateModel.Title,
            Description = playlistCreateModel.Description,
            Videos = videoIds,
            PlaylistThumbnail = this._attachmentService.CreateAttachmentFromCloudinaryPayload(thumbnailData)
        }, channelId);
    }
}
