using MeTube.Service.Models.Comments;

namespace MeTube.Service.Comments;

public interface IPlaylistCommentService
{
    Task<PlaylistCommentDto> GetByIdAsync(string id);

    IQueryable<PlaylistCommentDto> GetAll();

    Task<PlaylistCommentDto> CreateAsync(PlaylistCommentDto playlistCommentDto);

    Task<PlaylistCommentDto> EditAsync(PlaylistCommentDto playlistCommentDto);

    Task<PlaylistCommentDto> DeleteByIdAsync(string id);
}