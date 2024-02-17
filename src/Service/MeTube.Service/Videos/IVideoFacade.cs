using MeTube.Web.Models.Video;

namespace MeTube.Service.Videos;

public interface IVideoFacade 
{
    void Create(VideoCreateModel model);
}