using MeTube.Data.Models;
using MeTube.Data.Models.Channels;
using MeTube.Data.Repository.Channels;
using MeTube.Model.Mappings.Channels;
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
        Channel channel = channelDto.ToEntity();

        channel.User = meTubeUser;

        return (await this._channelRepository.CreateAsync(channel)).ToDto();
    }

    public async Task<ChannelDto> DeleteByIdAsync(string id)
    {
        Channel channel = await this.GetByIdInternalAsync(id);

        return (await this._channelRepository.DeleteAsync(channel)).ToDto();
    }

    public async Task<ChannelDto> EditAsync(ChannelDto channelDto)
    {
        Channel channel = channelDto.ToEntity();

        return (await this._channelRepository.EditAsync(channel)).ToDto();
    }

    public IQueryable<ChannelDto> GetAll()
    {
        return this._channelRepository.GetAllAsNoTracking()
            .Select(channel => channel.ToDto(true, true, true, true, true, true, true, true, true));
    }

    public async Task<ChannelDto> GetByIdAsync(string id)
    {
        return (await GetByIdInternalAsync(id)).ToDto();
    }

    private async Task<Channel> GetByIdInternalAsync(string id)
    {
        return await this._channelRepository.GetAll()
            .SingleOrDefaultAsync(channel => channel.Id == id);
    }
}