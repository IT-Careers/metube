using MeTube.Service.Models.Comments;
using MeTube.Service.Models.Reactions;
using MeTube.Service.Models.Videos;

namespace MeTube.Service.Models.Playlist;

public class PlaylistDto : MetadataBaseEntityDto
{
    public PlaylistDto()
    {
        Reactions = new List<PlaylistReactionDto>();
        Comments = new List<PlaylistCommentDto>();
        Videos = new List<VideoDto>();
    }
    public string Title { get; set; }

    public string Description { get; set; }

    public AttachmentDto PlaylistThumbnail { get; set; } // TODO: If null just make a thumbnail of 4 top videos

    public List<PlaylistReactionDto> Reactions { get; set; }

    public List<PlaylistCommentDto> Comments { get; set; }
    
    public List<VideoDto> Videos { get; set; }
}