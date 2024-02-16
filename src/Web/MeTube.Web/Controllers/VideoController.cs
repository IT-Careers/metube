using MeTube.Service.Videos;
using MeTube.Web.Models.Video;
using Microsoft.AspNetCore.Mvc;

namespace MeTube.Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoFacade videoFacade;

        public VideoController(IVideoFacade videoFacade)
        {
            this.videoFacade = videoFacade;
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(VideoCreateModel model)
        {
            videoFacade.Create(model);
    
            return RedirectToAction("Index", "Home");
        }
    }
}