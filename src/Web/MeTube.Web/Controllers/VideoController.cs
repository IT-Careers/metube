using MeTube.Data.Models;
using MeTube.Service.Videos;
using MeTube.Web.Models.Video;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeTube.Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoFacade _videoFacade;

        private readonly IVideoService _videoService;

        private readonly UserManager<MeTubeUser> _userManager;

        public VideoController(IVideoFacade videoFacade, UserManager<MeTubeUser> userManager, IVideoService videoService)
        {
            this._videoFacade = videoFacade;
            this._userManager = userManager;
            this._videoService = videoService;
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(VideoCreateModel model)
        {
            MeTubeUser currentUser = await this._userManager.GetUserAsync(this.User);

            await _videoFacade.Create(model, currentUser.Id);
    
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromQuery(Name = "v")] string videoId)
        {
            return View(await this._videoService.ViewVideoByIdAsync(videoId));
        }
    }
}