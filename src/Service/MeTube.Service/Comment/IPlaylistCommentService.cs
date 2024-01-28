using MeTube.Service.Models;

namespace MeTube.Service.Comment;

public interface IPlaylistCommentService
{
    Task<PlaylistCommentDto> GetByIdAsync(string id);

    IQueryable<PlaylistCommentDto> GetAll();

    Task<PlaylistCommentDto> CreateAsync(PlaylistCommentDto playlistCommentDto);

    Task<PlaylistCommentDto> EditAsync(PlaylistCommentDto playlistCommentDto);

    Task<PlaylistCommentDto> DeleteByIdAsync(string id);
}