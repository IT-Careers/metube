using MeTube.Data.Models.Comments;
using MeTube.Data.Repository;
using MeTube.Model.Mappings.Comments;
using MeTube.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service.Comment;

public class PlaylistCommentService : IPlaylistCommentService
{
    private readonly PlaylistCommentRepository _playlistCommentRepository;

    public PlaylistCommentService(PlaylistCommentRepository playlistCommentRepository)
    {
        this._playlistCommentRepository = playlistCommentRepository;
    }

    public async Task<PlaylistCommentDto> GetByIdAsync(string id)
    {
        return (await this.GetByIdInternalAsync(id)).ToDto();
    }

    public IQueryable<PlaylistCommentDto> GetAll()
    {
        return this._playlistCommentRepository.GetAllAsNoTracking().Select(playlistComment => playlistComment.ToDto());
    }

    public async Task<PlaylistCommentDto> CreateAsync(PlaylistCommentDto playlistCommentDto)
    {
        PlaylistComment playlistComment = playlistCommentDto.ToEntity();

        return (await this._playlistCommentRepository.CreateAsync(playlistComment)).ToDto();
    }

    public async Task<PlaylistCommentDto> EditAsync(PlaylistCommentDto playlistCommentDto)
    {
        PlaylistComment playlistComment = playlistCommentDto.ToEntity();

        return (await this._playlistCommentRepository.EditAsync(playlistComment)).ToDto();
    }

    public async Task<PlaylistCommentDto> DeleteByIdAsync(string id)
    {
        PlaylistComment playlistComment = await this.GetByIdInternalAsync(id);

        return (await this._playlistCommentRepository.DeleteAsync(playlistComment)).ToDto();
    }

    private async Task<PlaylistComment> GetByIdInternalAsync(string id)
    {
        return await this._playlistCommentRepository.GetAll()
            .SingleOrDefaultAsync(playlistComment => playlistComment.Id == id);
    }
}