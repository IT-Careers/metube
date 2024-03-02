using MeTube.Data.Models.Comments;
using MeTube.Service.Mappings.Channels;
using MeTube.Service.Mappings.Playlists;
using MeTube.Service.Mappings.Reactions;
using MeTube.Service.Models.Comments;

namespace MeTube.Service.Mappings.Comments;

public static class PlaylistCommentMapping
{
    public static PlaylistComment ToPlaylistCommentEntity(this PlaylistCommentDto playlistCommentDto)
    {
        PlaylistComment playlistComment = new PlaylistComment();

        playlistComment.Id = playlistCommentDto.Id;
        playlistComment.Content = playlistCommentDto.Content;
        playlistComment.CreatedBy = playlistCommentDto.CreatedBy?.ToChannelEntity();
        playlistComment.Playlist = playlistCommentDto.Playlist?.ToPlaylistEntity();
        playlistComment.Reactions = playlistCommentDto.Reactions?.Select(plcr => plcr.ToPlaylistCommentReactionEntity()).ToList();
        playlistComment.Replies = playlistCommentDto.Replies?.Select(plcr => plcr.ToPlaylistCommentEntity()).ToList();

        return playlistComment;
    }

    public static PlaylistCommentDto ToPlaylistCommentDto(this PlaylistComment playlistComment, bool includeChannel = true,
        bool includePlaylist = true, bool includeReactions = true)
    {
        PlaylistCommentDto playlistCommentDto = new PlaylistCommentDto();

        playlistCommentDto.Id = playlistComment.Id;
        playlistCommentDto.Content = playlistComment.Content;
        playlistCommentDto.Replies = playlistComment.Replies?.Select(plcr => plcr.ToPlaylistCommentDto(true)).ToList();

        playlistCommentDto.CreatedBy = includeChannel
            ? playlistComment.CreatedBy?.ToChannelDto(includePlaylistComments: false)
            : null;

        playlistCommentDto.Playlist = includePlaylist
            ? playlistComment.Playlist?.ToPlaylistDto(includeComments: false)
            : null;

        playlistCommentDto.Reactions = includeReactions
            ? playlistComment.Reactions?.Select(plcr => plcr.ToPlaylistCommentReactionDto(includeComment: false)).ToList()
            : null;

        return playlistCommentDto;
    }
}