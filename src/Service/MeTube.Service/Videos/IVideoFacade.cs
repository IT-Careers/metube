using MeTube.Web.Models.Video;

namespace MeTube.Service.Videos;

public interface IVideoFacade 
{
    Task Create(VideoCreateModel model, string userId);
}