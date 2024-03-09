using MeTube.Data.Models;
using MeTube.Service.Channels;
using MeTube.Service.Playlists;
using MeTube.Service.Reactions;
using MeTube.Service.Videos;
using MeTube.Web.Models.Comment;
using MeTube.Web.Models.Video;
using MeTube.Web.Utilities;
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

        private readonly IChannelService _channelService;

        private readonly IReactionTypeService _reactionTypeService;

        private readonly IPlaylistService _playlistService;

        private readonly UserManager<MeTubeUser> _userManager;

        public VideoController(
            IVideoFacade videoFacade, 
            UserManager<MeTubeUser> userManager, 
            IVideoService videoService, 
            IReactionTypeService reactionTypeService, 
            IChannelService channelService, 
            IPlaylistService playlistService)
        {
            this._videoFacade = videoFacade;
            this._userManager = userManager;
            this._videoService = videoService;
            this._reactionTypeService = reactionTypeService;
            this._channelService = channelService;
            this._playlistService = playlistService;
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
        public async Task<IActionResult> Details([FromQuery(Name = "v")] string videoId, [FromQuery(Name = "pl")] string playlistId)
        {
            MeTubeUser currentUser = await this._userManager.GetUserAsync(this.User);

            if(this.User.Identity.IsAuthenticated)
            {
                this.ViewData["Channel"] = await this._channelService.GetByUserIdAsync(currentUser.Id);
            }

            this.ViewData["ReactionTypes"] = await this._reactionTypeService.GetAll().ToListAsync();

            if(playlistId != null)
            {
                this.ViewData["Playlist"] = await this._playlistService.GetByIdAsync(playlistId);
            }

            var video = await this._videoService.ViewVideoByIdAsync(videoId);

            return View(video);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> React([FromQuery] string videoId, [FromQuery] string reactionTypeId)
        {
            MeTubeUser currentUser = await this._userManager.GetUserAsync(this.User);

            return Ok(await this._videoService.React(videoId, reactionTypeId, currentUser.Id));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Comment([FromQuery] string videoId, [FromBody] CommentCreateModel commentCreateModel)
        {
            MeTubeUser currentUser = await this._userManager.GetUserAsync(this.User);

            return Ok(await this._videoService.Comment(videoId, commentCreateModel.Content, currentUser.Id));
        }
    }
}