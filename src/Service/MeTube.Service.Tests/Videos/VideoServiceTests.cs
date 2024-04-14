using MeTube.Data.Models.Videos;
using MeTube.Data.Repository.Channels;
using MeTube.Data.Repository.Reactions;
using MeTube.Data.Repository.Videos;
using MeTube.Service.Playlists;
using MeTube.Service.Videos;
using MeTube.Service.Tests.Utilities;
using Moq;
using MeTube.Service.Mappings.Videos;

namespace MeTube.Service.Tests.Videos;

public class VideoServiceTests
{
    private Mock<IVideoRepository> videoRepositoryMock;

    private Mock<IChannelRepository> channelRepositoryMock;

    private Mock<IVideoReactionRepository> videoReactionRepositoryMock;

    private Mock<IReactionTypeRepository> reactionTypeRepositoryMock;

    private Mock<IPlaylistService> playlistServiceMock;

    private IVideoService videoService;

    private List<Video> GetTestVideoData()
    {
        return new List<Video>()
        {
            new Video()
            {
                Id = "1",
                Title = "Video-1"
            },
            new Video()
            {
                Id = "2",
                Title = "Video-2"
            },
            new Video()
            {
                Id = "3",
                Title = "Video-3"
            }
        };
    }

    [SetUp]
    public void BeforeEach()
    {
        this.videoRepositoryMock = new Mock<IVideoRepository>();
        this.channelRepositoryMock = new Mock<IChannelRepository>();
        this.videoReactionRepositoryMock = new Mock<IVideoReactionRepository>();
        this.reactionTypeRepositoryMock = new Mock<IReactionTypeRepository>();
        this.playlistServiceMock = new Mock<IPlaylistService>();

        this.videoService = new VideoService(
            videoRepositoryMock.Object,
            channelRepositoryMock.Object,
            playlistServiceMock.Object,
            videoReactionRepositoryMock.Object,
            reactionTypeRepositoryMock.Object
        );
    }

    [Test]
    public async Task TestGetByIdAsync_WithExistingId_ShouldCorrectlyReturnVideo()
    {
        // Arrange
        var testVideoDataQueryable = this.GetTestVideoData().AsQueryable();
        var mockSet = MoqExtensions.MockQueryable(testVideoDataQueryable);
        mockSet.As<IQueryable<Video>>().Setup(m => m.GetEnumerator()).Returns(() => testVideoDataQueryable.GetEnumerator());

        videoRepositoryMock.Setup(vr => vr.GetAll())
            .Returns(mockSet.Object);

        var expectedVideoId = "2";
        var expectedVideoTitle = "Video-2";

        // Act
        var actualVideo = await videoService.GetByIdAsync("2");

        var actualVideoId = actualVideo.Id;
        var actualVideoTitle = actualVideo.Title;

        // Assert
        Assert.That(actualVideoId, Is.EqualTo(expectedVideoId), "Video Ids differ.");
        Assert.That(actualVideoTitle, Is.EqualTo(expectedVideoTitle), "Video Titles differ.");
    }

    [Test]
    public async Task TestGetByIdAsync_WithNonExistingId_ShouldReturnNull()
    {
        // Arrange
        var testVideoDataQueryable = this.GetTestVideoData().AsQueryable();
        var mockSet = MoqExtensions.MockQueryable(testVideoDataQueryable);
        mockSet.As<IQueryable<Video>>().Setup(m => m.GetEnumerator()).Returns(() => testVideoDataQueryable.GetEnumerator());

        videoRepositoryMock.Setup(vr => vr.GetAll())
            .Returns(mockSet.Object);

        // Act & Assert
        Assert.That(
            async () => await this.videoService.GetByIdAsync("5"),
            Throws.Exception.TypeOf<ArgumentException>(),
            "Video Service does not throw exception for non existing video");
    }

    [Test]
    public async Task TestGetAll_WithTrackedAndExistingVideos_ShouldReturnCollectionOfVideos()
    {
        // Arrange
        var testVideoDataQueryable = this.GetTestVideoData().AsQueryable();
        var mockSet = MoqExtensions.MockQueryable(testVideoDataQueryable);
        mockSet.As<IQueryable<Video>>().Setup(m => m.GetEnumerator()).Returns(() => testVideoDataQueryable.GetEnumerator());

        videoRepositoryMock.Setup(vr => vr.GetAll())
            .Returns(mockSet.Object);

        var expectedCollection = this.GetTestVideoData().Select(video => video.ToVideoDto(true, true, true)).AsQueryable();

        // Act
        var actualQueryable = this.videoService.GetAll(true);

        // Assert
        var areEqual = MoqExtensions.CompareCollections(expectedCollection, actualQueryable, (firstVideo, secondVideo) =>
        {
            return firstVideo.Id == secondVideo.Id && firstVideo.Title == secondVideo.Title;
        });

        Assert.That(areEqual, Is.True);
    }

    [Test]
    public async Task TestGetAll_NonTrackedAndExistingVideos_ShouldReturnCollectionOfVideos()
    {
        // Arrange
        var testVideoDataQueryable = this.GetTestVideoData().AsQueryable();
        var mockSet = MoqExtensions.MockQueryable(testVideoDataQueryable);
        mockSet.As<IQueryable<Video>>().Setup(m => m.GetEnumerator()).Returns(() => testVideoDataQueryable.GetEnumerator());

        videoRepositoryMock.Setup(vr => vr.GetAllAsNoTracking())
            .Returns(mockSet.Object);

        var expectedCollection = this.GetTestVideoData().Select(video => video.ToVideoDto(true, true, true)).AsQueryable();

        // Act
        var actualQueryable = this.videoService.GetAll(false);

        // Assert
        var areEqual = MoqExtensions.CompareCollections(expectedCollection, actualQueryable, (firstVideo, secondVideo) =>
        {
            return firstVideo.Id == secondVideo.Id && firstVideo.Title == secondVideo.Title;
        });

        Assert.That(areEqual, Is.True);
    }

    [Test]
    public async Task TestGetAll_WithDefaultParameterAndExistingVideos_ShouldReturnCollectionOfVideos()
    {
        // Arrange
        var testVideoDataQueryable = this.GetTestVideoData().AsQueryable();
        var mockSet = MoqExtensions.MockQueryable(testVideoDataQueryable);
        mockSet.As<IQueryable<Video>>().Setup(m => m.GetEnumerator()).Returns(() => testVideoDataQueryable.GetEnumerator());

        videoRepositoryMock.Setup(vr => vr.GetAll())
            .Returns(mockSet.Object);

        var expectedVideoId = "2";
        var expectedVideoTitle = "Video-2";

        // Act
        var actualVideo = await videoService.GetByIdAsync("2");

        var actualVideoId = actualVideo.Id;
        var actualVideoTitle = actualVideo.Title;

        // Assert
        Assert.That(actualVideoId, Is.EqualTo(expectedVideoId), "Video Ids differ.");
        Assert.That(actualVideoTitle, Is.EqualTo(expectedVideoTitle), "Video Titles differ.");
    }
}
