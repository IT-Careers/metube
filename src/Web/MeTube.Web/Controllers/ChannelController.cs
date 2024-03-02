using MeTube.Service.Channels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MeTube.Web.Controllers
{
    public class ChannelController : Controller
    {
        private readonly IChannelService channelService;

        public ChannelController(IChannelService channelService)
        {
            this.channelService = channelService;
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromQuery] string channelId)
        {
            var channel = await this.channelService.GetByIdAsync(channelId);

            string currentChannelId = this.User.FindFirstValue("ChannelId");
            this.ViewData["IsSubscribedToChannel"] = channel.Subscribers.Any(channelSubscription => channelSubscription.Subscriber.Id == currentChannelId);

            return View(channel);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe([FromQuery] string channelId)
        {
            string currentChannelId = this.User.FindFirstValue("ChannelId");

            if(currentChannelId == channelId)
            {
                // TODO: Error: You can't subscribe to yourself.
                return RedirectToAction("Details", new { channelId } );
            }

            await this.channelService.SubscribeAsync(currentChannelId, channelId);

            return RedirectToAction("Details", new { channelId });
        }

        [HttpPost]
        public async Task<IActionResult> Unsubscribe([FromQuery] string channelId)
        {
            string currentChannelId = this.User.FindFirstValue("ChannelId");

            if (currentChannelId == channelId)
            {
                // TODO: Error: You can't unsubscribe of yourself.
                return RedirectToAction("Details", new { channelId });
            }

            await this.channelService.UnsubscribeAsync(currentChannelId, channelId);

            return RedirectToAction("Details", new { channelId });
        }
    }
}
