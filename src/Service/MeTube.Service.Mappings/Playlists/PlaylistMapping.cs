using MeTube.Data.Models.Playlists;
using MeTube.Service.Mappings.Channels;
using MeTube.Service.Mappings.Comments;
using MeTube.Service.Mappings.Reactions;
using MeTube.Service.Mappings.Videos;
using MeTube.Service.Models.Playlist;

namespace MeTube.Service.Mappings.Playlists;

public static class PlaylistMapping
{
    public static Playlist ToPlaylistEntity(this PlaylistDto playlistDto)
    {
        Playlist playlist = new Playlist();

        playlist.Id = playlistDto.Id ?? playlist.Id;
        playlist.Title = playlistDto.Title;
        playlist.Description = playlistDto.Description;
        playlist.PlaylistThumbnail = playlistDto.PlaylistThumbnail?.ToAttachmentEntity();
        playlist.Comments = playlistDto.Comments?.Select(plc => plc.ToPlaylistCommentEntity()).ToList();
        playlist.Reactions = playlistDto.Reactions?.Select(plr => plr.ToPlaylistReactionEntity()).ToList();
        //playlist.Videos = playlistDto.Videos?.Select(videoDto => videoDto.ToVideoEntity()).ToList();

        return playlist;
    }

    public static PlaylistDto ToPlaylistDto(this Playlist playlist, 
        bool includeChannel = true,
        bool includeVideos = true, 
        bool includeComments = true,
        bool includeReactions = true)
    {
        PlaylistDto playlistDto = new PlaylistDto();

        playlistDto.Id = playlist.Id;
        playlistDto.Title = playlist.Title;
        playlistDto.Description = playlist.Description;
        playlistDto.PlaylistThumbnail = playlist.PlaylistThumbnail?.ToAttachmentDto();
        playlistDto.CreatedBy = includeChannel
            ? playlist.CreatedBy?.ToChannelDto(
                includeVideoComments: false, 
                includeVideo: false,
                includePlaylist: false,
                includeVideoReactions: false,
                includePlaylistReactions: false,
                includeHistory: false,
                includePlaylistComments: false,
                includeSubscribers: false,
                includeSubscriptions: false)
            : null;

        playlistDto.Videos = includeVideos
            ? playlist.Videos?.Select(playlistVideoMappingEntity => playlistVideoMappingEntity.ToPlaylistVideoMappingDto(includePlaylist: false)).ToList()
            : null;

        playlistDto.Comments = includeComments
            ? playlist.Comments?.Select(plc => plc.ToPlaylistCommentDto(includePlaylist: false)).ToList()
            : null;

        playlistDto.Reactions = includeReactions
            ? playlist.Reactions?.Select(plr => plr.ToPlaylistReactionDto(includePlaylist: false)).ToList()
            : null;


        return playlistDto;
    }
}