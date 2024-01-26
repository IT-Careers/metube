using MeTube.Data.Models.Comments;
using MeTube.Data.Models.Playlists;
using MeTube.Data.Models.Reactions;
using MeTube.Data.Models.Videos;
using MeTube.Service.Models;
using MeTube.Service.Models.Playlist;
using MeTube.Service.Models.Reactions;

namespace MeTube.Model.Mappings;

public static class PlaylistMapping
{
    public static Playlist ToEntity(PlaylistDto dto)
    {
        Playlist entity = new Playlist();

        entity.Id = dto.Id;
        entity.Title = dto.Title;
        entity.Description = dto.Description;
        entity.PlaylistThumbnail = AttachmentMapping.ToEntity(dto.PlaylistThumbnail);
        //TODO use PlaylistComment Mapping
        entity.Comments = new List<PlaylistComment>(); 
        //TODO use PlaylistReaction Mapping
        entity.Reactions = new List<PlaylistReaction>();
        entity.Videos = dto.Videos
            .Select(videoDto => VideoMapping.ToEntity(videoDto))
            .ToList();
        

        return entity;
    }

    public static PlaylistDto ToDto(Playlist entity)
    {
        PlaylistDto dto = new PlaylistDto();

        dto.Id = entity.Id;
        dto.Title = entity.Title;
        dto.Description = entity.Description;
        dto.PlaylistThumbnail = AttachmentMapping.ToDto(entity.PlaylistThumbnail);
        //TODO use PlaylistComment Mapping
        dto.Comments = new List<PlaylistCommentDto>(); 
        //TODO use PlaylistReaction Mapping
        dto.Reactions = new List<PlaylistReactionDto>();
        dto.Videos = entity.Videos
            .Select(videoEntity => VideoMapping.ToDto(videoEntity))
            .ToList();

        return dto;
    }
}