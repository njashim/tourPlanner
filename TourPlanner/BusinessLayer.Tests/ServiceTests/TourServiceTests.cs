using AutoMapper;
using BusinessLayer.Service;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interface;
using Model;
using Moq;

namespace BusinessLayer.Tests.ServiceTests
{
    [TestFixture]
    public class TourServiceTests
    {
        private Mock<ITourRepository> _tourRepositoryMock;
        private IMapper _mapper;
        private TourService _tourService;

        [SetUp]
        //public void SetUp()
        //{
        //    _tourRepositoryMock = new Mock<ITourRepository>();

        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile<BusinessLayer.Mapping.MappingProfile>();
        //    });
        //    _mapper = config.CreateMapper();

        //    _tourService = new TourService(_tourRepositoryMock.Object, _mapper);
        //}

        [Test]
        public async Task CreateTourAsync_ShouldReturnTourModel_WhenTourIsCreated()
        {
            var newTourModel = new TourModel
            {
                Name = "New Tour",
                FromLocation = "Location A",
                ToLocation = "Location B",
                TransportType = "Car",
                Distance = 100,
                EstimatedTime = TimeSpan.FromHours(2)
            };

            var createdTour = new Tour
            {
                Id = Guid.NewGuid(),
                Name = "New Tour",
                FromLocation = "Location A",
                ToLocation = "Location B",
                TransportType = "Car",
                Distance = 100,
                EstimatedTime = TimeSpan.FromHours(2)
            };

            _tourRepositoryMock.Setup(repo => repo.CreateTourAsync(It.IsAny<Tour>()))
                               .ReturnsAsync(createdTour);

            var result = await _tourService.CreateTourAsync(newTourModel);

            Assert.That(result.Id, Is.EqualTo(createdTour.Id));
            Assert.That(result.Name, Is.EqualTo(createdTour.Name));
            Assert.That(result.FromLocation, Is.EqualTo(createdTour.FromLocation));
            Assert.That(result.ToLocation, Is.EqualTo(createdTour.ToLocation));
            Assert.That(result.TransportType, Is.EqualTo(createdTour.TransportType));
            Assert.That(result.Distance, Is.EqualTo(createdTour.Distance));
            Assert.That(result.EstimatedTime, Is.EqualTo(createdTour.EstimatedTime));
        }

        [Test]
        public void GetTours_ShouldReturnListOfTourModel_WhenToursExist()
        {
            var tours = new List<Tour>
            {
                new Tour
                {
                    Id = Guid.NewGuid(),
                    Name = "Tour 1",
                    FromLocation = "Location A",
                    ToLocation = "Location B",
                    TransportType = "Car",
                    Distance = 100,
                    EstimatedTime = TimeSpan.FromHours(2)
                },
                new Tour
                {
                    Id = Guid.NewGuid(),
                    Name = "Tour 2",
                    FromLocation = "Location C",
                    ToLocation = "Location D",
                    TransportType = "Bike",
                    Distance = 50,
                    EstimatedTime = TimeSpan.FromHours(1)
                }
            };

            _tourRepositoryMock.Setup(repo => repo.GetTours())
                               .Returns(tours);

            var result = _tourService.GetTours();

            Assert.That(result.Count, Is.EqualTo(tours.Count));
            for (int i = 0; i < tours.Count; i++)
            {
                Assert.That(result[i].Id, Is.EqualTo(tours[i].Id));
                Assert.That(result[i].Name, Is.EqualTo(tours[i].Name));
                Assert.That(result[i].FromLocation, Is.EqualTo(tours[i].FromLocation));
                Assert.That(result[i].ToLocation, Is.EqualTo(tours[i].ToLocation));
                Assert.That(result[i].TransportType, Is.EqualTo(tours[i].TransportType));
                Assert.That(result[i].Distance, Is.EqualTo(tours[i].Distance));
                Assert.That(result[i].EstimatedTime, Is.EqualTo(tours[i].EstimatedTime));
            }
        }

        [Test]
        public void GetTourById_ShouldReturnTourModel_WhenTourExists()
        {
            var tourId = Guid.NewGuid();
            var tour = new Tour
            {
                Id = tourId,
                Name = "Sample Tour",
                FromLocation = "Location A",
                ToLocation = "Location B",
                TransportType = "Car",
                Distance = 100,
                EstimatedTime = TimeSpan.FromHours(2)
            };

            _tourRepositoryMock.Setup(repo => repo.GetTourById(tourId))
                               .Returns(tour);

            var result = _tourService.GetTourById(tourId);

            Assert.That(result.Id, Is.EqualTo(tour.Id));
            Assert.That(result.Name, Is.EqualTo(tour.Name));
            Assert.That(result.FromLocation, Is.EqualTo(tour.FromLocation));
            Assert.That(result.ToLocation, Is.EqualTo(tour.ToLocation));
            Assert.That(result.TransportType, Is.EqualTo(tour.TransportType));
            Assert.That(result.Distance, Is.EqualTo(tour.Distance));
            Assert.That(result.EstimatedTime, Is.EqualTo(tour.EstimatedTime));
        }

        [Test]
        public async Task UpdateTourAsync_ShouldReturnUpdatedTourModel_WhenTourIsUpdated()
        {
            var updatedTourModel = new TourModel
            {
                Id = Guid.NewGuid(),
                Name = "Updated Tour",
                FromLocation = "Location A",
                ToLocation = "Location B",
                TransportType = "Car",
                Distance = 150,
                EstimatedTime = TimeSpan.FromHours(3)
            };

            var updatedTour = new Tour
            {
                Id = updatedTourModel.Id,
                Name = "Updated Tour",
                FromLocation = "Location A",
                ToLocation = "Location B",
                TransportType = "Car",
                Distance = 150,
                EstimatedTime = TimeSpan.FromHours(3)
            };

            _tourRepositoryMock.Setup(repo => repo.UpdateTourAsync(It.IsAny<Tour>()))
                               .ReturnsAsync(updatedTour);

            var result = await _tourService.UpdateTourAsync(updatedTourModel);

            Assert.That(result.Id, Is.EqualTo(updatedTour.Id));
            Assert.That(result.Name, Is.EqualTo(updatedTour.Name));
            Assert.That(result.FromLocation, Is.EqualTo(updatedTour.FromLocation));
            Assert.That(result.ToLocation, Is.EqualTo(updatedTour.ToLocation));
            Assert.That(result.TransportType, Is.EqualTo(updatedTour.TransportType));
            Assert.That(result.Distance, Is.EqualTo(updatedTour.Distance));
            Assert.That(result.EstimatedTime, Is.EqualTo(updatedTour.EstimatedTime));
        }

        [Test]
        public async Task DeleteTourAsync_ShouldCallRepositoryDeleteTourAsync_WhenCalled()
        {
            var tourId = Guid.NewGuid();

            await _tourService.DeleteTourAsync(tourId);

            _tourRepositoryMock.Verify(repo => repo.DeleteTourAsync(tourId), Times.Once);
        }
    }
}
