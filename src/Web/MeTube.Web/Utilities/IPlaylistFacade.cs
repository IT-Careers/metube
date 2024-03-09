using MeTube.Web.Models.Playlist;

namespace MeTube.Web.Utilities;

public interface IPlaylistFacade
{
    Task CreatePlaylist(PlaylistCreateModel playlistCreateModel, string channelId);
}
