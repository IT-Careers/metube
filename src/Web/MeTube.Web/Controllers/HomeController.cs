using MeTube.Service.Videos;
using Microsoft.AspNetCore.Mvc;

namespace MeTube.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVideoService _videoService;

        public HomeController(IVideoService videoService)
        {
            this._videoService = videoService;
        }

        public IActionResult Index()
        {
            return View(this._videoService.GetAll().ToList());
        }
    }
}
