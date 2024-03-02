using MeTube.Data.Models;
using MeTube.Data.Models.Channels;
using MeTube.Data.Repository.Channels;
using MeTube.Service.Mappings.Channels;
using MeTube.Service.Models.Channels;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service.Channels;

public class ChannelService : IChannelService
{
    private readonly ChannelRepository _channelRepository;

    public ChannelService(ChannelRepository channelRepository)
    {
        this._channelRepository = channelRepository;
    }

    public async Task<ChannelDto> CreateAsync(ChannelDto channelDto, MeTubeUser meTubeUser)
    {
        Channel channel = channelDto.ToChannelEntity();

        channel.User = meTubeUser;

        return (await this._channelRepository.CreateAsync(channel)).ToChannelDto();
    }

    public async Task<ChannelDto> DeleteByIdAsync(string id)
    {
        Channel channel = await this.GetByIdInternalAsync(id);

        return (await this._channelRepository.DeleteAsync(channel)).ToChannelDto();
    }

    public async Task<ChannelDto> EditAsync(ChannelDto channelDto)
    {
        Channel channel = channelDto.ToChannelEntity();

        return (await this._channelRepository.EditAsync(channel)).ToChannelDto();
    }

    public IQueryable<Channel> GetAll()
    {
        return this._channelRepository.GetAllAsNoTracking()
            .Include(channel => channel.User)
            .Include(channel => channel.ProfilePicture)
            .Include(channel => channel.CoverPicture)
            .Include(channel => channel.Subscribers)
            .Include(channel => channel.Subscriptions)
            .Include(channel => channel.History)
                .ThenInclude(history => history.Video)
                    .ThenInclude(video => video.Thumbnail)
            .Include(channel => channel.History)
                .ThenInclude(history => history.Video)
                    .ThenInclude(video => video.CreatedBy)
                        .ThenInclude(channel => channel.ProfilePicture)
            .Include(channel => channel.Videos)
                .ThenInclude(video => video.Thumbnail)
            .Include(channel => channel.Videos)
                .ThenInclude(video => video.VideoFile)
            .Include(channel => channel.VideoComments)
            .Include(channel => channel.VideoReactions)
            .Include(channel => channel.Playlists)
            .Include(channel => channel.PlaylistComments)
            .Include(channel => channel.PlaylistReactions);
    }

    public async Task<ChannelDto> GetByIdAsync(string id)
    {
        return (await GetByIdInternalAsync(id)).ToChannelDto();
    }

    public async Task<ChannelDto> GetByUserIdAsync(string userId)
    {
        return (this.GetAll()
            .SingleOrDefault(channel => channel.User.Id == userId))
            .ToChannelDto();
    }

    private async Task<Channel> GetByIdInternalAsync(string id)
    {
        return await this.GetAll()
            .SingleOrDefaultAsync(channel => channel.Id == id);
    }
}