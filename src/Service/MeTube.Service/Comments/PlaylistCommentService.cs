using MeTube.Data.Models.Comments;
using MeTube.Data.Repository.Comments;
using MeTube.Model.Mappings.Comments;
using MeTube.Service.Models.Comments;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service.Comments;

public class PlaylistCommentService : IPlaylistCommentService
{
    private readonly PlaylistCommentRepository _playlistCommentRepository;

    public PlaylistCommentService(PlaylistCommentRepository playlistCommentRepository)
    {
        _playlistCommentRepository = playlistCommentRepository;
    }

    public async Task<PlaylistCommentDto> GetByIdAsync(string id)
    {
        return (await GetByIdInternalAsync(id)).ToDto();
    }

    public IQueryable<PlaylistCommentDto> GetAll()
    {
        return _playlistCommentRepository.GetAllAsNoTracking()
            .Select(playlistComment => playlistComment.ToDto(true, true, true));
    }

    public async Task<PlaylistCommentDto> CreateAsync(PlaylistCommentDto playlistCommentDto)
    {
        PlaylistComment playlistComment = playlistCommentDto.ToEntity();

        return (await _playlistCommentRepository.CreateAsync(playlistComment)).ToDto();
    }

    public async Task<PlaylistCommentDto> EditAsync(PlaylistCommentDto playlistCommentDto)
    {
        PlaylistComment playlistComment = playlistCommentDto.ToEntity();

        return (await _playlistCommentRepository.EditAsync(playlistComment)).ToDto();
    }

    public async Task<PlaylistCommentDto> DeleteByIdAsync(string id)
    {
        PlaylistComment playlistComment = await GetByIdInternalAsync(id);

        return (await _playlistCommentRepository.DeleteAsync(playlistComment)).ToDto();
    }

    private async Task<PlaylistComment> GetByIdInternalAsync(string id)
    {
        return await _playlistCommentRepository.GetAll()
            .SingleOrDefaultAsync(playlistComment => playlistComment.Id == id);
    }
}