using Microsoft.AspNetCore.Http;

namespace MeTube.Web.Models.Reactions;

public class ReactionTypeCreateModel
{
    public string Type { get; set; }

    public IFormFile Icon { get; set; }
}
