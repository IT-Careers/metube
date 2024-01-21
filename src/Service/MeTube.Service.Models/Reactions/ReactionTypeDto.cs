using System.Net.Mail;

namespace MeTube.Service.Models.Reactions;

public class ReactionTypeDto : BaseEntityDto
{
    public AttachmentDto ReactionIcon { get; set; }

    public string Type { get; set; }
}