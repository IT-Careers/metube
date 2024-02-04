// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using MeTube.Data.Models;
using MeTube.Model.Mappings;
using MeTube.Service;
using MeTube.Service.Attachments;
using MeTube.Service.Channels;
using MeTube.Service.Models.Channels;
using MeTube.Web.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeTube.Web.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<MeTubeUser> _signInManager;
        private readonly UserManager<MeTubeUser> _userManager;
        private readonly IUserStore<MeTubeUser> _userStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IChannelService _channelService;
        private readonly IAttachmentService _attachmentService;
        private readonly ICloudinaryService _cloudinaryService;

        public RegisterModel(
            UserManager<MeTubeUser> userManager,
            IUserStore<MeTubeUser> userStore,
            SignInManager<MeTubeUser> signInManager,
            ILogger<RegisterModel> logger,
            IChannelService channelService,
            IAttachmentService attachmentService,
            ICloudinaryService cloudinaryService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;
            _channelService = channelService;
            _attachmentService = attachmentService;
            _cloudinaryService = cloudinaryService;
        }

        [BindProperty]
        public RegisterRequestModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    MeTubeUser newlyRegisteredUser = await _userStore.FindByIdAsync(user.Id, CancellationToken.None);
                    ChannelDto channel = await this.CreateChannel();
                    
                    await _channelService.CreateAsync(channel, newlyRegisteredUser);

                    _logger.LogInformation($"Successfully created channel - {channel.Name}.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private MeTubeUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<MeTubeUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(MeTubeUser)}'. " +
                    $"Ensure that '{nameof(MeTubeUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private async Task<ChannelDto> CreateChannel()
        {
            ChannelDto channelDto = new ChannelDto();

            channelDto.About = this.Input.About;
            channelDto.Name = this.Input.Username;

            var profilePictureUploadResult = await this._cloudinaryService.UploadFile(Input.ProfilePicture);
            channelDto.ProfilePicture = this._attachmentService.CreateAttachmentFromCloudinaryPayload(profilePictureUploadResult);

            var coverPictureUploadResult = await this._cloudinaryService.UploadFile(Input.CoverPicture);
            channelDto.CoverPicture = this._attachmentService.CreateAttachmentFromCloudinaryPayload(coverPictureUploadResult);
            
            return channelDto;
        }
    }
}
