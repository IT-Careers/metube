using Microsoft.AspNetCore.Http;

namespace MeTube.Web.Models.Playlist;

public class PlaylistCreateModel 
{
    public string Title { get; set; }
    
    public string Description { get;set; }
    
    public IFormFile Thumbnail { get;set; }

    public string VideoIds { get; set; }
}