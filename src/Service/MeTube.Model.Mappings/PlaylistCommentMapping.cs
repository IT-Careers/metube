using MeTube.Data.Models;
using MeTube.Data.Models.Comments;
using MeTube.Data.Models.Reactions;
using MeTube.Service.Models;
using MeTube.Service.Models.Reactions;

namespace MeTube.Model.Mappings;

public static class PlaylistCommentMapping
{
    public static PlaylistComment ToEntity(PlaylistCommentDto dto)
    {
        PlaylistComment entity = new PlaylistComment();

        entity.Content = dto.Content;
        //TODO replace with MeTubeUserMapping
        entity.Poster = new MeTubeUser();
        entity.Playlist = PlaylistMapping.ToEntity(dto.Playlist);
        //TODO replace with PlaylistCommentReactionMapping
        entity.Reactions = new List<PlaylistCommentReaction>();
        entity.Replies = dto.Replies
            .Select(commentDto => ToEntity(commentDto))
            .ToList();
            
        return entity;
    }
    
    public static PlaylistCommentDto ToDto(PlaylistComment entity)
    {
        PlaylistCommentDto dto = new PlaylistCommentDto();

        dto.Content = entity.Content;
        //TODO replace with MeTubeUserMapping
        dto.Poster = new MeTubeUserDto();
        dto.Playlist = PlaylistMapping.ToDto(entity.Playlist);
        //TODO replace with PlaylistCommentReactionMapping
        dto.Reactions = new List<PlaylistCommentReactionDto>();
        dto.Replies = entity.Replies
            .Select(commentDto => ToDto(commentDto))
            .ToList();
            
        return dto;
    }
}