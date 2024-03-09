using MeTube.Data.Models.Channels;
using MeTube.Data.Models.Comments;
using MeTube.Data.Models.Reactions;
using MeTube.Data.Models.Videos;
using MeTube.Data.Repository.Channels;
using MeTube.Data.Repository.Reactions;
using MeTube.Data.Repository.Videos;
using MeTube.Service.Mappings.Videos;
using MeTube.Service.Models.Videos;
using MeTube.Service.Playlists;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service.Videos;

public class VideoService : IVideoService
{
    private readonly VideoRepository _videoRepository;

    private readonly ChannelRepository _channelRepository;

    private readonly VideoReactionRepository _videoReactionRepository;

    private readonly ReactionTypeRepository _reactionTypeRepository;

    private readonly IPlaylistService _playlistService;

    public VideoService(
        VideoRepository videoRepository, 
        ChannelRepository channelRepository, 
        IPlaylistService playlistService, 
        VideoReactionRepository videoReactionRepository, 
        ReactionTypeRepository reactionTypeRepository)
    {
        this._videoRepository = videoRepository;
        this._channelRepository = channelRepository;
        this._playlistService = playlistService;
        this._videoReactionRepository = videoReactionRepository;
        this._reactionTypeRepository = reactionTypeRepository;
    }

    public async Task<VideoDto> GetByIdAsync(string id)
    {
        return (await this.GetByIdInternalAsync(id)).ToVideoDto();
    }

    public IQueryable<VideoDto> GetAll()
    {
        return this._videoRepository.GetAllAsNoTracking()
            .Include(video => video.VideoFile) 
            .Include(video => video.Thumbnail)
            .Include(video => video.CreatedBy).ThenInclude(channel => channel.ProfilePicture)
            .Include(video => video.Comments)
                .ThenInclude(videoComment => videoComment.CreatedBy)
            .Include(video => video.Reactions)
                .ThenInclude(videoReaction => videoReaction.Channel)
            .Include(video => video.Reactions)
                .ThenInclude(videoReaction => videoReaction.Type)
                .ThenInclude(reactionType => reactionType.ReactionIcon)
            .Select(video => video.ToVideoDto(true, true, true));
    }

    public async Task<ICollection<VideoDto>> GetAllPlaylistVideos(string playlistId)
    {
        return null;
        //return (await this._playlistService.GetByIdAsync(playlistId)).Videos;
    }

    public async Task<VideoDto> CreateAsync(VideoDto videoDto, string userId)
    {
        Channel? channel = this._channelRepository.GetAll()
            .Include(channel => channel.User)
            .SingleOrDefault(channel => channel.User.Id == userId);

        if (channel == null)
        {
            throw new Exception("Channel with the given user id does not exist.");
        }

        Video video = videoDto.ToVideoEntity();
        video.CreatedBy = channel;

        return (await _videoRepository.CreateAsync(video)).ToVideoDto(true);
    }

    public async Task<VideoDto> EditAsync(VideoDto videoDto)
    {
        Video video = videoDto.ToVideoEntity();

        return (await _videoRepository.EditAsync(video)).ToVideoDto();
    }

    public async Task<VideoDto> DeleteByIdAsync(string id)
    {
        Video video = await this.GetByIdInternalAsync(id);

        return (await _videoRepository.DeleteAsync(video)).ToVideoDto();
    }

    public async Task<VideoDto> ViewVideoByIdAsync(string videoId)
    {
        Video video = await this.GetByIdInternalAsync(videoId);
        video.Views++;
        await this._videoRepository.EditAsync(video);
        return video.ToVideoDto();
    }

    public async Task<VideoDto> React(string videoId, string reactionTypeId, string userId)
    {
        Channel? channel = this._channelRepository.GetAll()
            .Include(channel => channel.User)
            .SingleOrDefault(channel => channel.User.Id == userId);

        ReactionType? reactionType = this._reactionTypeRepository.GetAll()
            .Include(reactionType => reactionType.ReactionIcon)
            .SingleOrDefault(reactionType => reactionType.Id == reactionTypeId);

        Video videoEntity = await this.GetByIdInternalAsync(videoId);

        List<VideoReaction> existentVideoReactions = await this._videoReactionRepository.GetAll()
            .Include(videoReaction => videoReaction.Channel)
            .Include(videoReaction => videoReaction.Video)
            .Where(videoReaction => videoReaction.Video.Id == videoId && videoReaction.Channel.Id == channel.Id)
            .ToListAsync();

        if (existentVideoReactions.Count > 0)
        {
            foreach (var videoReactionToDelete in existentVideoReactions)
            {
                await this._videoReactionRepository.DeleteAsync(videoReactionToDelete);
            }
        }

        VideoReaction videoReaction = new VideoReaction
        {
            Channel = channel,
            Type = reactionType
        };

        videoEntity.Reactions.Add(videoReaction);

        return (await this._videoRepository.EditAsync(videoEntity)).ToVideoDto();
    }

    public async Task<VideoDto> Comment(string videoId, string content, string userId)
    {
        Channel? channel = this._channelRepository.GetAll()
            .Include(channel => channel.User)
            .SingleOrDefault(channel => channel.User.Id == userId);

        Video videoEntity = await this.GetByIdInternalAsync(videoId);

        VideoComment videoComment = new VideoComment
        {
            CreatedBy = channel,
            Content = content,
        };

        videoEntity.Comments.Add(videoComment);
        return (await this._videoRepository.EditAsync(videoEntity)).ToVideoDto();
    }

    private async Task<Video> GetByIdInternalAsync(string id)
    {
        return await this.GetAllTracked().SingleOrDefaultAsync(video => video.Id == id);
    }

    private IQueryable<Video> GetAllTracked()
    {
        return this._videoRepository.GetAll()
            .Include(video => video.Thumbnail)
            .Include(video => video.VideoFile)
            .Include(video => video.Comments)
                .ThenInclude(videoComment => videoComment.CreatedBy)
                    .ThenInclude(channel => channel.ProfilePicture)
            .Include(video => video.Reactions)
                .ThenInclude(reaction => reaction.Type)
                .ThenInclude(reactionType => reactionType.ReactionIcon)
            .Include(video => video.CreatedBy)
                .ThenInclude(channel => channel.ProfilePicture)
            .Include(video => video.CreatedBy)
                .ThenInclude(channel => channel.CoverPicture)
            .Include(video => video.CreatedBy)
                .ThenInclude(channel => channel.Subscribers)
                .ThenInclude(subscriber => subscriber.Subscriber);
    }

    public IQueryable<VideoDto> GetSubscriptionVideos(string channelId, int count = 10)
    {
        return this.GetAllTracked()
            .Where(video => video.CreatedBy.Subscribers.Any(subscriber => subscriber.Subscriber.Id == channelId))
            .Take(count)
            .Select(video => video.ToVideoDto(false, false, true));
    }

    public IQueryable<VideoDto> GetRandomVideos(HashSet<string> excludedVideoIds)
    {
        return this.GetAllTracked()
            .Where(video => !excludedVideoIds.Contains(video.Id))
            .Select(video => video.ToVideoDto(false, false, true));
    }
}