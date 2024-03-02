using MeTube.Service.Channels;
using MeTube.Service.Models.Channels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MeTube.Web.ViewComponents;

[ViewComponent]
public class ChannelSubscriptionsViewComponent : ViewComponent
{
    private readonly IChannelService _channelService;

    public ChannelSubscriptionsViewComponent(IChannelService channelService)
    {
        this._channelService = channelService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var currentChannelId = (this.User as ClaimsPrincipal).FindFirst("ChannelId")?.Value;

        if (currentChannelId != null)
        {
            var currentChannel = await this._channelService.GetByIdAsync(currentChannelId);

            return View(currentChannel.Subscriptions.Select(subscription => subscription.Subscription).ToList());
        }

        return View(new List<ChannelDto>());
    }
}
