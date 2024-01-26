using MeTube.Service.Models.Reactions;

namespace MeTube.Service.Models.Playlist;

public class PlaylistDto : BaseEntityDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public AttachmentDto PlaylistThumbnail { get; set; } // TODO: If null just make a thumbnail of 4 top videos

    public List<PlaylistReactionDto> Reactions { get; set; }

    public List<PlaylistCommentDto> Comments { get; set; }
    
    public List<VideoDto> Videos { get; set; }
}