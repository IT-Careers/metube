using Microsoft.AspNetCore.Http;

namespace MeTube.Web.Models.Video;

public class VideoCreateModel 
{
    public string Title { get; set; }
    public string Description { get;set; }
    public IFormFile Video { get;set; }
    public IFormFile Thumbnail { get;set; }
}