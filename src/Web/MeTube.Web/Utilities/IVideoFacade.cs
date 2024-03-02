using MeTube.Web.Models.Video;

namespace MeTube.Web.Utilities;

public interface IVideoFacade 
{
    Task Create(VideoCreateModel model, string userId);
}