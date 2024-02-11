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

    public static PlaylistCommentDto ToDto(this PlaylistComment playlistComment, bool includeChannel = true,
        bool includePlaylist = true, bool includeReactions = true)
    {
        PlaylistCommentDto playlistCommentDto = new PlaylistCommentDto();

        playlistCommentDto.Id = playlistComment.Id;
        playlistCommentDto.Content = playlistComment.Content;
        playlistCommentDto.Replies = playlistComment.Replies.Select(plcr => plcr.ToDto(true)).ToList();

        playlistCommentDto.CreatedBy = includeChannel
            ? playlistComment.CreatedBy.ToDto(includePlaylistComment: false)
            : null;

        playlistCommentDto.Playlist = includePlaylist
            ? playlistComment.Playlist.ToDto(includeComments: false)
            : null;

        playlistCommentDto.Reactions = includeReactions
            ? playlistComment.Reactions.Select(plcr => plcr.ToDto(includeComment: false)).ToList()
            : null;

        return playlistCommentDto;
    }
}