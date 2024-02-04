using MeTube.Data.Models;
using MeTube.Service.Models.Channels;

namespace MeTube.Service.Channels;

public interface IChannelService
{
    Task<ChannelDto> GetByIdAsync(string id);

    IQueryable<ChannelDto> GetAll();

    Task<ChannelDto> CreateAsync(ChannelDto channelDto, MeTubeUser user);

    Task<ChannelDto> EditAsync(ChannelDto channelDto);

    Task<ChannelDto> DeleteByIdAsync(string id);
}
