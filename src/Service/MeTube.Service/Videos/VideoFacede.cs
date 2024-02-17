using MeTube.Service.Models.Videos;
using MeTube.Web.Models.Video;
using MeTube.Service.Attachments;
using Microsoft.AspNetCore.Http;

namespace MeTube.Service.Videos;

public class VideoFacade : IVideoFacade 
{
    private readonly ICloudinaryService cloudinaryService;
    private readonly IVideoService videoService;
    private readonly IAttachmentService attachmentService;

    public VideoFacade(ICloudinaryService cloudinaryService, IVideoService videoService, IAttachmentService attachmentService)
    {
        this.cloudinaryService = cloudinaryService;
        this.videoService = videoService;
        this.attachmentService = attachmentService;
    }

    public async void Create(VideoCreateModel model)
    {
        ValidateVideoExtensions(model.Video);

        var videoData = await cloudinaryService.UploadFile(model.Video);
        var thumbnailData = await cloudinaryService.UploadFile(model.Thumbnail);

        VideoDto dto = new VideoDto
        {
            Title = model.Title,
            Description = model.Description,
            VideoFile = attachmentService.CreateAttachmentFromCloudinaryPayload(videoData),
            Thumbnail = attachmentService.CreateAttachmentFromCloudinaryPayload(thumbnailData)
        };

        await videoService.CreateAsync(dto);
    }

    private void ValidateVideoExtensions(IFormFile formFile) {

    }
}