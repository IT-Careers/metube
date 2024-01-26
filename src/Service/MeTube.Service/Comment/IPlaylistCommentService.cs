using MeTube.Service.Models;

namespace MeTube.Service.Comment;

public interface IPlaylistCommentService
{
    Task<PlaylistCommentDto> GetById(string id);
    Task<PlaylistCommentDto> Create(PlaylistCommentDto playlistCommentDto);
    Task<PlaylistCommentDto> Edit(PlaylistCommentDto playlistCommentDto);
    Task<PlaylistCommentDto> DeleteById(string id);
}