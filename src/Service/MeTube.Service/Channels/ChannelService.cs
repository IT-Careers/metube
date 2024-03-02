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

    private readonly ChannelSubscriptionMappingRepository _channelSubscriptionMappingRepository;

    public ChannelService(ChannelRepository channelRepository, ChannelSubscriptionMappingRepository channelSubscriptionMappingRepository)
    {
        this._channelRepository = channelRepository;
        this._channelSubscriptionMappingRepository = channelSubscriptionMappingRepository;
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

    public IQueryable<Channel> GetAll(bool tracked = false)
    {
        var entities = tracked ? this.GetAllTracked() : this.GetAllAsNoTracking();

        return entities
            .Include(channel => channel.User)
            .Include(channel => channel.ProfilePicture)
            .Include(channel => channel.CoverPicture)
            .Include(channel => channel.Subscribers)
                .ThenInclude(channelSubscriber => channelSubscriber.Subscriber)
            .Include(channel => channel.Subscriptions)
                .ThenInclude(channelSubscription => channelSubscription.Subscription)
                .ThenInclude(channelSubscription => channelSubscription.ProfilePicture)
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

    public async Task SubscribeAsync(string subscriberId, string subscriptionId)
    {
        Channel subscriberChannel = await this.GetAll(true).SingleOrDefaultAsync(channel => channel.Id == subscriberId);
        Channel subscriptionChannel = await this.GetAll(true).SingleOrDefaultAsync(channel => channel.Id == subscriptionId);

        if(subscriberChannel.Subscriptions.Any(subscription => subscription.Subscription.Id == subscriptionId))
        {
            return;
        }

        await this._channelSubscriptionMappingRepository.CreateAsync(new ChannelSubscriptionsMapping
        {
            Subscriber = subscriberChannel,
            Subscription = subscriptionChannel,
            Timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds()
        });
    }

    public async Task UnsubscribeAsync(string subscriberId, string subscriptionId)
    {
        var channelSubscriptionMappingToDelete = await this._channelSubscriptionMappingRepository.GetAll()
            .Include(channelSubscriptionMapping => channelSubscriptionMapping.Subscriber)
            .Include(channelSubscriptionMapping => channelSubscriptionMapping.Subscription)
            .SingleOrDefaultAsync(
            channelSubscriptionMapping => channelSubscriptionMapping.Subscriber.Id == subscriberId
            && channelSubscriptionMapping.Subscription.Id == subscriptionId);

        if(channelSubscriptionMappingToDelete != null)
        {
            await this._channelSubscriptionMappingRepository.DeleteAsync(channelSubscriptionMappingToDelete);
        }
    }

    private async Task<Channel> GetByIdInternalAsync(string id)
    {
        return await this.GetAll()
            .SingleOrDefaultAsync(channel => channel.Id == id);
    }

    private IQueryable<Channel> GetAllAsNoTracking()
    {
        return this._channelRepository.GetAllAsNoTracking();
    }

    private IQueryable<Channel> GetAllTracked()
    {
        return this._channelRepository.GetAll();
    }
}