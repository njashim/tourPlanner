using AutoMapper;
using BusinessLayer.Service;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interface;
using Model;
using Moq;

namespace BusinessLayer.Tests.ServiceTests
{
    [TestFixture]
    public class TourLogServiceTests
    {
        private Mock<ITourLogRepository> _tourLogRepositoryMock;
        private IMapper _mapper;
        private TourLogService _tourLogService;

        [SetUp]
        public void SetUp()
        {
            _tourLogRepositoryMock = new Mock<ITourLogRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BusinessLayer.Mapping.MappingProfile>();
            });
            _mapper = config.CreateMapper();

            _tourLogService = new TourLogService(_tourLogRepositoryMock.Object, _mapper);
        }

        [Test]
        public async Task CreateTourLogAsync_ShouldReturnTourLogModel_WhenTourLogIsCreated()
        {
            var newTourLogModel = new TourLogModel
            {
                TourId = Guid.NewGuid(),
                DateTime = DateTime.Now,
                Comment = "New Tour Log",
                Difficulty = 3,
                TotalDistance = 100.0,
                TotalTime = TimeSpan.FromHours(2),
                Rating = 5
            };

            var createdTourLog = new TourLog
            {
                Id = Guid.NewGuid(),
                TourId = newTourLogModel.TourId,
                DateTime = newTourLogModel.DateTime,
                Comment = "New Tour Log",
                Difficulty = 3,
                TotalDistance = 100.0,
                TotalTime = TimeSpan.FromHours(2),
                Rating = 5
            };

            _tourLogRepositoryMock.Setup(repo => repo.CreateTourLogAsync(It.IsAny<TourLog>()))
                                  .ReturnsAsync(createdTourLog);

            var result = await _tourLogService.CreateTourLogAsync(newTourLogModel);

            Assert.That(result.Id, Is.EqualTo(createdTourLog.Id));
            Assert.That(result.TourId, Is.EqualTo(createdTourLog.TourId));
            Assert.That(result.DateTime, Is.EqualTo(createdTourLog.DateTime));
            Assert.That(result.Comment, Is.EqualTo(createdTourLog.Comment));
            Assert.That(result.Difficulty, Is.EqualTo(createdTourLog.Difficulty));
            Assert.That(result.TotalDistance, Is.EqualTo(createdTourLog.TotalDistance));
            Assert.That(result.TotalTime, Is.EqualTo(createdTourLog.TotalTime));
            Assert.That(result.Rating, Is.EqualTo(createdTourLog.Rating));
        }

        [Test]
        public void GetTourLogs_ShouldReturnListOfTourLogModel_WhenTourLogsExist()
        {
            var tourLogs = new List<TourLog>
            {
                new TourLog
                {
                    Id = Guid.NewGuid(),
                    TourId = Guid.NewGuid(),
                    DateTime = DateTime.Now,
                    Comment = "Log 1",
                    Difficulty = 2,
                    TotalDistance = 100.0,
                    TotalTime = TimeSpan.FromHours(1.5),
                    Rating = 4
                },
                new TourLog
                {
                    Id = Guid.NewGuid(),
                    TourId = Guid.NewGuid(),
                    DateTime = DateTime.Now,
                    Comment = "Log 2",
                    Difficulty = 3,
                    TotalDistance = 200.0,
                    TotalTime = TimeSpan.FromHours(2.5),
                    Rating = 5
                }
            };

            _tourLogRepositoryMock.Setup(repo => repo.GetTourLogs())
                                  .Returns(tourLogs);

            var result = _tourLogService.GetTourLogs();

            Assert.That(result.Count, Is.EqualTo(tourLogs.Count));
            for (int i = 0; i < tourLogs.Count; i++)
            {
                Assert.That(result[i].Id, Is.EqualTo(tourLogs[i].Id));
                Assert.That(result[i].TourId, Is.EqualTo(tourLogs[i].TourId));
                Assert.That(result[i].DateTime, Is.EqualTo(tourLogs[i].DateTime));
                Assert.That(result[i].Comment, Is.EqualTo(tourLogs[i].Comment));
                Assert.That(result[i].Difficulty, Is.EqualTo(tourLogs[i].Difficulty));
                Assert.That(result[i].TotalDistance, Is.EqualTo(tourLogs[i].TotalDistance));
                Assert.That(result[i].TotalTime, Is.EqualTo(tourLogs[i].TotalTime));
                Assert.That(result[i].Rating, Is.EqualTo(tourLogs[i].Rating));
            }
        }

        [Test]
        public void GetTourLogById_ShouldReturnTourLogModel_WhenTourLogExists()
        {
            var tourLogId = Guid.NewGuid();
            var tourLog = new TourLog
            {
                Id = tourLogId,
                TourId = Guid.NewGuid(),
                DateTime = DateTime.Now,
                Comment = "Sample Log",
                Difficulty = 3,
                TotalDistance = 150.0,
                TotalTime = TimeSpan.FromHours(2),
                Rating = 4
            };

            _tourLogRepositoryMock.Setup(repo => repo.GetTourLogById(tourLogId))
                                  .Returns(tourLog);

            var result = _tourLogService.GetTourLogById(tourLogId);

            Assert.That(result.Id, Is.EqualTo(tourLog.Id));
            Assert.That(result.TourId, Is.EqualTo(tourLog.TourId));
            Assert.That(result.DateTime, Is.EqualTo(tourLog.DateTime));
            Assert.That(result.Comment, Is.EqualTo(tourLog.Comment));
            Assert.That(result.Difficulty, Is.EqualTo(tourLog.Difficulty));
            Assert.That(result.TotalDistance, Is.EqualTo(tourLog.TotalDistance));
            Assert.That(result.TotalTime, Is.EqualTo(tourLog.TotalTime));
            Assert.That(result.Rating, Is.EqualTo(tourLog.Rating));
        }

        [Test]
        public async Task UpdateTourLogAsync_ShouldReturnUpdatedTourLogModel_WhenTourLogIsUpdated()
        {
            var updatedTourLogModel = new TourLogModel
            {
                Id = Guid.NewGuid(),
                TourId = Guid.NewGuid(),
                DateTime = DateTime.Now,
                Comment = "Updated Log",
                Difficulty = 4,
                TotalDistance = 120.0,
                TotalTime = TimeSpan.FromHours(1.8),
                Rating = 5
            };

            var updatedTourLog = new TourLog
            {
                Id = updatedTourLogModel.Id,
                TourId = updatedTourLogModel.TourId,
                DateTime = updatedTourLogModel.DateTime,
                Comment = "Updated Log",
                Difficulty = 4,
                TotalDistance = 120.0,
                TotalTime = TimeSpan.FromHours(1.8),
                Rating = 5
            };

            _tourLogRepositoryMock.Setup(repo => repo.UpdateTourLogAsync(It.IsAny<TourLog>()))
                                  .ReturnsAsync(updatedTourLog);

            var result = await _tourLogService.UpdateTourLogAsync(updatedTourLogModel);

            Assert.That(result.Id, Is.EqualTo(updatedTourLog.Id));
            Assert.That(result.TourId, Is.EqualTo(updatedTourLog.TourId));
            Assert.That(result.DateTime, Is.EqualTo(updatedTourLog.DateTime));
            Assert.That(result.Comment, Is.EqualTo(updatedTourLog.Comment));
            Assert.That(result.Difficulty, Is.EqualTo(updatedTourLog.Difficulty));
            Assert.That(result.TotalDistance, Is.EqualTo(updatedTourLog.TotalDistance));
            Assert.That(result.TotalTime, Is.EqualTo(updatedTourLog.TotalTime));
            Assert.That(result.Rating, Is.EqualTo(updatedTourLog.Rating));
        }

        [Test]
        public async Task DeleteTourLogAsync_ShouldCallRepositoryDeleteTourLogAsync_WhenCalled()
        {
            var tourLogId = Guid.NewGuid();

            await _tourLogService.DeleteTourLogAsync(tourLogId);

            _tourLogRepositoryMock.Verify(repo => repo.DeleteTourLogAsync(tourLogId), Times.Once);
        }
    }
}
