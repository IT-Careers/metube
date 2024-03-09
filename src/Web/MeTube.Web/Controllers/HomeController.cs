using MeTube.Data.Models;
using MeTube.Service.Models.Channels;
using MeTube.Service.Models.Videos;
using MeTube.Service.Videos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MeTube.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVideoService _videoService;

        private readonly UserManager<MeTubeUser> _userManager;

        public HomeController(IVideoService videoService, UserManager<MeTubeUser> userManager)
        {
            this._videoService = videoService;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            HashSet<string> excludedVideoIds = new HashSet<string>();

            if (this.User.Identity.IsAuthenticated)
            {
                string currentChannelId = this.User.FindFirstValue("ChannelId");

                List<VideoDto> subscriptionVideos = await this._videoService.GetSubscriptionVideos(currentChannelId).ToListAsync();
                subscriptionVideos.ForEach(video => excludedVideoIds.Add(video.Id));

                // TODO: Refactor use of View Model
                this.ViewData["SubscriptionVideos"] = subscriptionVideos;
            }

            // TODO: Refactor use of View Model
            this.ViewData["RandomVideos"] = await this._videoService.GetRandomVideos(excludedVideoIds).ToListAsync();

            return View();
        }
    }
}
