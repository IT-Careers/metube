using MeTube.Data.Models.Comments;
using MeTube.Data.Repository;
using MeTube.Model.Mappings.Comments;
using MeTube.Service.Models;

namespace MeTube.Service.Comment;

public class PlaylistCommentService : IPlaylistCommentService
{
    private readonly PlaylistCommentRepository _playlistCommentRepository;

    public PlaylistCommentService(PlaylistCommentRepository playlistCommentRepository)
    {
        _playlistCommentRepository = playlistCommentRepository;
    }

    public async Task<PlaylistCommentDto> GetById(string id)
    {
        return PlaylistCommentMapping.ToDto(GetByIdInternal(id));
    }

    public async Task<PlaylistCommentDto> Create(PlaylistCommentDto playlistCommentDto)
    {
        PlaylistComment playlistComment = PlaylistCommentMapping.ToEntity(playlistCommentDto);

        return PlaylistCommentMapping.ToDto(await _playlistCommentRepository.Create(playlistComment));
    }

    public async Task<PlaylistCommentDto> Edit(PlaylistCommentDto playlistCommentDto)
    {
        PlaylistComment playlistComment = PlaylistCommentMapping.ToEntity(playlistCommentDto);

        return PlaylistCommentMapping.ToDto(await _playlistCommentRepository.Edit(playlistComment));
    }

    public async Task<PlaylistCommentDto> DeleteById(string id)
    {
        PlaylistComment playlistComment = GetByIdInternal(id);

        return PlaylistCommentMapping.ToDto(await _playlistCommentRepository.Delete(playlistComment));
    }

    private PlaylistComment GetByIdInternal(string id)
    {
        return _playlistCommentRepository.GetAll()
            .Result
            .First(playlistComment => playlistComment.Id == id);
    }
}