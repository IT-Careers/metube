using MeTube.Service.Playlists;
using MeTube.Web.Models.Playlist;
using MeTube.Web.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MeTube.Web.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistService _playlistService;

        private readonly IPlaylistFacade _playlistFacade;

        public PlaylistController(IPlaylistService playlistService, IPlaylistFacade playlistFacade)
        {
            this._playlistService = playlistService;
            this._playlistFacade = playlistFacade;
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromQuery] string playlistId)
        {
            return View(await this._playlistService.GetByIdAsync(playlistId));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlaylistCreateModel playlistCreateModel)
        {
            string currentChannelId = this.User.FindFirstValue("ChannelId");

            await this._playlistFacade.CreatePlaylist(playlistCreateModel, currentChannelId);

            return Redirect("/");
        }

    }
}
