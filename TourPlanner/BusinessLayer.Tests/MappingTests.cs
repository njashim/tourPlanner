using AutoMapper;
using BusinessLayer.Mapping;
using DataAccessLayer.Entity;
using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Tests.Mapping
{
    public class MappingProfileTests
    {
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BusinessLayer.Mapping.MappingProfile>();
            });
            _mapper = config.CreateMapper();
        }

        [Test]
        public void MappingConfiguration_IsValid()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            config.AssertConfigurationIsValid();
        }

        [Test]
        public void Should_Map_Tour_To_TourModel()
        {
            var tour = new Tour
            {
                Id = Guid.NewGuid(),
                Name = "Sample Tour",
                Description = "Sample Description",
                FromLocation = "Location A",
                ToLocation = "Location B",
                TransportType = "Car",
                Distance = 100.5,
                EstimatedTime = TimeSpan.FromHours(2),
                RouteImagePath = "path/to/image.jpg"
            };

            var tourModel = _mapper.Map<TourModel>(tour);

            Assert.That(tourModel.Id, Is.EqualTo(tour.Id));
            Assert.That(tourModel.Name, Is.EqualTo(tour.Name));
            Assert.That(tourModel.Description, Is.EqualTo(tour.Description));
            Assert.That(tourModel.FromLocation, Is.EqualTo(tour.FromLocation));
            Assert.That(tourModel.ToLocation, Is.EqualTo(tour.ToLocation));
            Assert.That(tourModel.TransportType, Is.EqualTo(tour.TransportType));
            Assert.That(tourModel.Distance, Is.EqualTo(tour.Distance));
            Assert.That(tourModel.EstimatedTime, Is.EqualTo(tour.EstimatedTime));
            Assert.That(tourModel.RouteImagePath, Is.EqualTo(tour.RouteImagePath));
        }

        [Test]
        public void Should_Map_TourLog_To_TourLogModel()
        {
            var tourLog = new TourLog
            {
                Id = Guid.NewGuid(),
                TourId = Guid.NewGuid(),
                DateTime = DateTime.Now,
                Comment = "Great tour!",
                Difficulty = 3,
                TotalDistance = 150.5,
                TotalTime = TimeSpan.FromHours(3.5),
                Rating = 5
            };

            var tourLogModel = _mapper.Map<TourLogModel>(tourLog);

            Assert.That(tourLogModel.Id, Is.EqualTo(tourLog.Id));
            Assert.That(tourLogModel.TourId, Is.EqualTo(tourLog.TourId));
            Assert.That(tourLogModel.DateTime, Is.EqualTo(tourLog.DateTime));
            Assert.That(tourLogModel.Comment, Is.EqualTo(tourLog.Comment));
            Assert.That(tourLogModel.Difficulty, Is.EqualTo(tourLog.Difficulty));
            Assert.That(tourLogModel.TotalDistance, Is.EqualTo(tourLog.TotalDistance));
            Assert.That(tourLogModel.TotalTime, Is.EqualTo(tourLog.TotalTime));
            Assert.That(tourLogModel.Rating, Is.EqualTo(tourLog.Rating));
        }

        [Test]
        public void Should_Map_TourModel_To_Tour()
        {
            var tourModel = new TourModel
            {
                Id = Guid.NewGuid(),
                Name = "Sample Tour Model",
                Description = "Sample Description",
                FromLocation = "Location A",
                ToLocation = "Location B",
                TransportType = "Bike",
                Distance = 200.5,
                EstimatedTime = TimeSpan.FromHours(4),
                RouteImagePath = "path/to/another_image.jpg"
            };

            var tour = _mapper.Map<Tour>(tourModel);

            Assert.That(tour.Id, Is.EqualTo(tourModel.Id));
            Assert.That(tour.Name, Is.EqualTo(tourModel.Name));
            Assert.That(tour.Description, Is.EqualTo(tourModel.Description));
            Assert.That(tour.FromLocation, Is.EqualTo(tourModel.FromLocation));
            Assert.That(tour.ToLocation, Is.EqualTo(tourModel.ToLocation));
            Assert.That(tour.TransportType, Is.EqualTo(tourModel.TransportType));
            Assert.That(tour.Distance, Is.EqualTo(tourModel.Distance));
            Assert.That(tour.EstimatedTime, Is.EqualTo(tourModel.EstimatedTime));
            Assert.That(tour.RouteImagePath, Is.EqualTo(tourModel.RouteImagePath));
        }

        [Test]
        public void Should_Map_TourLogModel_To_TourLog()
        {
            var tourLogModel = new TourLogModel
            {
                Id = Guid.NewGuid(),
                TourId = Guid.NewGuid(),
                DateTime = DateTime.Now,
                Comment = "Challenging but fun!",
                Difficulty = 4,
                TotalDistance = 175.0,
                TotalTime = TimeSpan.FromHours(5),
                Rating = 4
            };

            var tourLog = _mapper.Map<TourLog>(tourLogModel);

            Assert.That(tourLog.Id, Is.EqualTo(tourLogModel.Id));
            Assert.That(tourLog.TourId, Is.EqualTo(tourLogModel.TourId));
            Assert.That(tourLog.DateTime, Is.EqualTo(tourLogModel.DateTime));
            Assert.That(tourLog.Comment, Is.EqualTo(tourLogModel.Comment));
            Assert.That(tourLog.Difficulty, Is.EqualTo(tourLogModel.Difficulty));
            Assert.That(tourLog.TotalDistance, Is.EqualTo(tourLogModel.TotalDistance));
            Assert.That(tourLog.TotalTime, Is.EqualTo(tourLogModel.TotalTime));
            Assert.That(tourLog.Rating, Is.EqualTo(tourLogModel.Rating));
        }

        [Test]
        public void Should_Map_ListOfTour_To_ListOfTourModel()
        {
            var tours = new List<Tour>
            {
                new Tour
                {
                    Id = Guid.NewGuid(),
                    Name = "Tour 1",
                    Description = "Description 1",
                    FromLocation = "Location A",
                    ToLocation = "Location B",
                    TransportType = "Car",
                    Distance = 100.5,
                    EstimatedTime = TimeSpan.FromHours(2),
                    RouteImagePath = "path/to/image1.jpg"
                },
                new Tour
                {
                    Id = Guid.NewGuid(),
                    Name = "Tour 2",
                    Description = "Description 2",
                    FromLocation = "Location C",
                    ToLocation = "Location D",
                    TransportType = "Bike",
                    Distance = 50.0,
                    EstimatedTime = TimeSpan.FromHours(1),
                    RouteImagePath = "path/to/image2.jpg"
                }
            };

            var tourModels = _mapper.Map<List<TourModel>>(tours);

            Assert.That(tourModels.Count, Is.EqualTo(tours.Count));
            for (int i = 0; i < tours.Count; i++)
            {
                Assert.That(tourModels[i].Id, Is.EqualTo(tours[i].Id));
                Assert.That(tourModels[i].Name, Is.EqualTo(tours[i].Name));
                Assert.That(tourModels[i].Description, Is.EqualTo(tours[i].Description));
                Assert.That(tourModels[i].FromLocation, Is.EqualTo(tours[i].FromLocation));
                Assert.That(tourModels[i].ToLocation, Is.EqualTo(tours[i].ToLocation));
                Assert.That(tourModels[i].TransportType, Is.EqualTo(tours[i].TransportType));
                Assert.That(tourModels[i].Distance, Is.EqualTo(tours[i].Distance));
                Assert.That(tourModels[i].EstimatedTime, Is.EqualTo(tours[i].EstimatedTime));
                Assert.That(tourModels[i].RouteImagePath, Is.EqualTo(tours[i].RouteImagePath));
            }
        }

        [Test]
        public void Should_Map_ListOfTourModel_To_ListOfTour()
        {
            var tourModels = new List<TourModel>
            {
                new TourModel
                {
                    Id = Guid.NewGuid(),
                    Name = "TourModel 1",
                    Description = "Description 1",
                    FromLocation = "Location A",
                    ToLocation = "Location B",
                    TransportType = "Car",
                    Distance = 100.5,
                    EstimatedTime = TimeSpan.FromHours(2),
                    RouteImagePath = "path/to/image1.jpg"
                },
                new TourModel
                {
                    Id = Guid.NewGuid(),
                    Name = "TourModel 2",
                    Description = "Description 2",
                    FromLocation = "Location C",
                    ToLocation = "Location D",
                    TransportType = "Bike",
                    Distance = 50.0,
                    EstimatedTime = TimeSpan.FromHours(1),
                    RouteImagePath = "path/to/image2.jpg"
                }
            };

            var tours = _mapper.Map<List<Tour>>(tourModels);

            Assert.That(tours.Count, Is.EqualTo(tourModels.Count));
            for (int i = 0; i < tourModels.Count; i++)
            {
                Assert.That(tours[i].Id, Is.EqualTo(tourModels[i].Id));
                Assert.That(tours[i].Name, Is.EqualTo(tourModels[i].Name));
                Assert.That(tours[i].Description, Is.EqualTo(tourModels[i].Description));
                Assert.That(tours[i].FromLocation, Is.EqualTo(tourModels[i].FromLocation));
                Assert.That(tours[i].ToLocation, Is.EqualTo(tourModels[i].ToLocation));
                Assert.That(tours[i].TransportType, Is.EqualTo(tourModels[i].TransportType));
                Assert.That(tours[i].Distance, Is.EqualTo(tourModels[i].Distance));
                Assert.That(tours[i].EstimatedTime, Is.EqualTo(tourModels[i].EstimatedTime));
                Assert.That(tours[i].RouteImagePath, Is.EqualTo(tourModels[i].RouteImagePath));
            }
        }

        [Test]
        public void Should_Map_ListOfTourLog_To_ListOfTourLogModel()
        {
            var tourLogs = new List<TourLog>
            {
                new TourLog
                {
                    Id = Guid.NewGuid(),
                    TourId = Guid.NewGuid(),
                    DateTime = DateTime.Now,
                    Comment = "Comment 1",
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
                    Comment = "Comment 2",
                    Difficulty = 3,
                    TotalDistance = 200.0,
                    TotalTime = TimeSpan.FromHours(2.5),
                    Rating = 5
                }
            };

            var tourLogModels = _mapper.Map<List<TourLogModel>>(tourLogs);

            Assert.That(tourLogModels.Count, Is.EqualTo(tourLogs.Count));
            for (int i = 0; i < tourLogs.Count; i++)
            {
                Assert.That(tourLogModels[i].Id, Is.EqualTo(tourLogs[i].Id));
                Assert.That(tourLogModels[i].TourId, Is.EqualTo(tourLogs[i].TourId));
                Assert.That(tourLogModels[i].DateTime, Is.EqualTo(tourLogs[i].DateTime));
                Assert.That(tourLogModels[i].Comment, Is.EqualTo(tourLogs[i].Comment));
                Assert.That(tourLogModels[i].Difficulty, Is.EqualTo(tourLogs[i].Difficulty));
                Assert.That(tourLogModels[i].TotalDistance, Is.EqualTo(tourLogs[i].TotalDistance));
                Assert.That(tourLogModels[i].TotalTime, Is.EqualTo(tourLogs[i].TotalTime));
                Assert.That(tourLogModels[i].Rating, Is.EqualTo(tourLogs[i].Rating));
            }
        }

        [Test]
        public void Should_Map_ListOfTourLogModel_To_ListOfTourLog()
        {
            var tourLogModels = new List<TourLogModel>
            {
                new TourLogModel
                {
                    Id = Guid.NewGuid(),
                    TourId = Guid.NewGuid(),
                    DateTime = DateTime.Now,
                    Comment = "Comment 1",
                    Difficulty = 2,
                    TotalDistance = 100.0,
                    TotalTime = TimeSpan.FromHours(1.5),
                    Rating = 4
                },
                new TourLogModel
                {
                    Id = Guid.NewGuid(),
                    TourId = Guid.NewGuid(),
                    DateTime = DateTime.Now,
                    Comment = "Comment 2",
                    Difficulty = 3,
                    TotalDistance = 200.0,
                    TotalTime = TimeSpan.FromHours(2.5),
                    Rating = 5
                }
            };

            var tourLogs = _mapper.Map<List<TourLog>>(tourLogModels);

            Assert.That(tourLogs.Count, Is.EqualTo(tourLogModels.Count));
            for (int i = 0; i < tourLogModels.Count; i++)
            {
                Assert.That(tourLogs[i].Id, Is.EqualTo(tourLogModels[i].Id));
                Assert.That(tourLogs[i].TourId, Is.EqualTo(tourLogModels[i].TourId));
                Assert.That(tourLogs[i].DateTime, Is.EqualTo(tourLogModels[i].DateTime));
                Assert.That(tourLogs[i].Comment, Is.EqualTo(tourLogModels[i].Comment));
                Assert.That(tourLogs[i].Difficulty, Is.EqualTo(tourLogModels[i].Difficulty));
                Assert.That(tourLogs[i].TotalDistance, Is.EqualTo(tourLogModels[i].TotalDistance));
                Assert.That(tourLogs[i].TotalTime, Is.EqualTo(tourLogModels[i].TotalTime));
                Assert.That(tourLogs[i].Rating, Is.EqualTo(tourLogModels[i].Rating));
            }
        }
    }
}
