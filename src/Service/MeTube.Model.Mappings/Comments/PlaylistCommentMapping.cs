using MeTube.Data.Models.Comments;
using MeTube.Model.Mappings.Channels;
using MeTube.Model.Mappings.Playlists;
using MeTube.Model.Mappings.Reactions;
using MeTube.Service.Models.Comments;

namespace MeTube.Model.Mappings.Comments;

public static class PlaylistCommentMapping
{
    public static PlaylistComment ToEntity(this PlaylistCommentDto playlistCommentDto)
    {
        PlaylistComment playlistComment = new PlaylistComment();

        playlistComment.Id = playlistCommentDto.Id;
        playlistComment.Content = playlistCommentDto.Content;
        playlistComment.CreatedBy = playlistCommentDto.CreatedBy.ToEntity();
        playlistComment.Playlist = playlistCommentDto.Playlist.ToEntity();
        playlistComment.Reactions = playlistCommentDto.Reactions.Select(plcr => plcr.ToEntity()).ToList();
        playlistComment.Replies = playlistCommentDto.Replies.Select(plcr => plcr.ToEntity()).ToList();

        return playlistComment;
    }

    public static PlaylistCommentDto ToDto(this PlaylistComment playlistComment)
    {
        PlaylistCommentDto playlistCommentDto = new PlaylistCommentDto();

        playlistCommentDto.Id = playlistComment.Id;
        playlistCommentDto.Content = playlistComment.Content;
        playlistCommentDto.Channel = playlistComment.CreatedBy.ToDto();
        playlistCommentDto.Playlist = playlistComment.Playlist.ToDto();
        playlistCommentDto.Reactions = playlistComment.Reactions.Select(plcr => plcr.ToDto()).ToList();
        playlistCommentDto.Replies = playlistComment.Replies.Select(plcr => plcr.ToDto()).ToList();

        return playlistCommentDto;
    }
}