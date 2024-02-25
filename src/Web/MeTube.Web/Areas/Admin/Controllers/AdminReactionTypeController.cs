using MeTube.Service;
using MeTube.Service.Attachments;
using MeTube.Service.Models.Reactions;
using MeTube.Service.Reactions;
using MeTube.Web.Models.Reactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminReactionTypeController : Controller
{
    private readonly IReactionTypeService _reactionTypeService;

    private readonly ICloudinaryService _cloudinaryService;

    private readonly IAttachmentService _attachmentService;

    public AdminReactionTypeController(
        IReactionTypeService reactionTypeService, 
        ICloudinaryService cloudinaryService, 
        IAttachmentService attachmentService)
    {
        this._reactionTypeService = reactionTypeService;
        this._cloudinaryService = cloudinaryService;
        _attachmentService = attachmentService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await this._reactionTypeService.GetAll().ToListAsync());
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ReactionTypeCreateModel reactionTypeCreateModel)
    {
        var iconData = await this._cloudinaryService.UploadFile(reactionTypeCreateModel.Icon);

        ReactionTypeDto reactionTypeDto = new ReactionTypeDto
        {
            Type = reactionTypeCreateModel.Type,
            ReactionIcon = this._attachmentService.CreateAttachmentFromCloudinaryPayload(iconData)
        };

        await this._reactionTypeService.CreateAsync(reactionTypeDto);

        return RedirectToAction("Index");
    }
}
