using MeTube.Data.Models;
using MeTube.Service.Reactions;
using MeTube.Service.Videos;
using MeTube.Web.Models.Video;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoFacade _videoFacade;

        private readonly IVideoService _videoService;

        private readonly IReactionTypeService _reactionTypeService;

        private readonly UserManager<MeTubeUser> _userManager;

        public VideoController(IVideoFacade videoFacade, UserManager<MeTubeUser> userManager, IVideoService videoService, IReactionTypeService reactionTypeService)
        {
            this._videoFacade = videoFacade;
            this._userManager = userManager;
            this._videoService = videoService;
            this._reactionTypeService = reactionTypeService;
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
            this.ViewData["ReactionTypes"] = await this._reactionTypeService.GetAll().ToListAsync();

            return View(await this._videoService.ViewVideoByIdAsync(videoId));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> React([FromQuery] string videoId, [FromQuery] string reactionTypeId)
        {
            MeTubeUser currentUser = await this._userManager.GetUserAsync(this.User);

            return Ok(await this._videoService.React(videoId, reactionTypeId, currentUser.Id));
        }
    }
}