using MeTube.Data.Models.Comments;
using MeTube.Data.Repository.Comments;
using MeTube.Service.Mappings.Comments;
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
        return (await GetByIdInternalAsync(id)).ToPlaylistCommentDto();
    }

    public IQueryable<PlaylistCommentDto> GetAll()
    {
        return _playlistCommentRepository.GetAllAsNoTracking()
            .Select(playlistComment => playlistComment.ToPlaylistCommentDto(true, true, true));
    }

    public async Task<PlaylistCommentDto> CreateAsync(PlaylistCommentDto playlistCommentDto)
    {
        PlaylistComment playlistComment = playlistCommentDto.ToPlaylistCommentEntity();

        return (await _playlistCommentRepository.CreateAsync(playlistComment)).ToPlaylistCommentDto();
    }

    public async Task<PlaylistCommentDto> EditAsync(PlaylistCommentDto playlistCommentDto)
    {
        PlaylistComment playlistComment = playlistCommentDto.ToPlaylistCommentEntity();

        return (await _playlistCommentRepository.EditAsync(playlistComment)).ToPlaylistCommentDto();
    }

    public async Task<PlaylistCommentDto> DeleteByIdAsync(string id)
    {
        PlaylistComment playlistComment = await GetByIdInternalAsync(id);

        return (await _playlistCommentRepository.DeleteAsync(playlistComment)).ToPlaylistCommentDto();
    }

    private async Task<PlaylistComment> GetByIdInternalAsync(string id)
    {
        return await _playlistCommentRepository.GetAll()
            .SingleOrDefaultAsync(playlistComment => playlistComment.Id == id);
    }
}