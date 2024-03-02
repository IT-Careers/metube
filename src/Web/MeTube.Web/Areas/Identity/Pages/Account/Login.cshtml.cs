// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MeTube.Data.Models;
using MeTube.Web.Models.Identity;
using System.Security.Claims;
using MeTube.Service.Channels;

namespace MeTube.Web.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<MeTubeUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IChannelService _channelService;
        private readonly UserManager<MeTubeUser> _userManager;

        public LoginModel(SignInManager<MeTubeUser> signInManager, ILogger<LoginModel> logger, IChannelService channelService, UserManager<MeTubeUser> userManager)
        {
            this._signInManager = signInManager;
            this._logger = logger;
            this._channelService = channelService;
            this._userManager = userManager;
        }

        [BindProperty]
        public LoginRequestModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                MeTubeUser user = await this._userManager.FindByNameAsync(Input.Email);
                var result = await this._signInManager.CheckPasswordSignInAsync(user, Input.Password, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    string channelId = await this.GetChannelIdAsync(user.Id);
                    await this._signInManager.SignInWithClaimsAsync(user, true, new[] { new Claim("ChannelId", channelId) });
                    this._logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = true });
                }
                if (result.IsLockedOut)
                {
                    this._logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private async Task<string> GetChannelIdAsync(string userId)
        {
            return (await this._channelService.GetByUserIdAsync(userId)).Id;
        }
    }
}
