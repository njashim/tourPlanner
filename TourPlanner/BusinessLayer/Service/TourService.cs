using BusinessLayer.Service.Interface;
using DataAccessLayer.Entity;
using DataAccessLayer.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class TourService : ITourService
    {
        private readonly TourPlannerContext _context;

        public List<Tour> Tours { get; set; } = new List<Tour>();

        public Tour? newTour { get; set; } = new Tour();

        public TourService(TourPlannerContext context)
        {
            _context = context;
        }

        public async Task CreateTourAsync()
        {
            if (newTour is null)
            {
                return;
            }

            try
            {
                newTour.RouteImagePath = "MussGeandertWerden";
                _context.Tours.Add(newTour);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

            }
        }
          

        public List<TourModel> GetTours()
        {
            var tours = _context.Tours.ToList();
            var tourModels = new List<TourModel>();

            foreach (var tour in tours)
            {
                tourModels.Add(new TourModel
                {
                    Id = tour.Id,
                    Name = tour.Name,
                    Description = tour.Description,
                    FromLocation = tour.FromLocation,
                    ToLocation = tour.ToLocation,
                    TransportType = tour.TransportType,
                    Distance = tour.Distance,
                    EstimatedTime = tour.EstimatedTime,
                    RouteImagePath = tour.RouteImagePath
                });
            }

            return tourModels;
        }

        public TourModel GetTourById(Guid tourModelId)
        {
            var tour = _context.Tours.Find(tourModelId);
            if (tour == null)
                return null;

            var tourModel = new TourModel
            {
                Id = tour.Id,
                Name = tour.Name,
                Description = tour.Description,
                FromLocation = tour.FromLocation,
                ToLocation = tour.ToLocation,
                TransportType = tour.TransportType,
                Distance = tour.Distance,
                EstimatedTime = tour.EstimatedTime,
                RouteImagePath = tour.RouteImagePath
            };

            return tourModel;
        }

        public async Task<TourModel> UpdateTourAsync(TourModel updatedTourModel)
        {
            var tour = await _context.Tours.FindAsync(updatedTourModel.Id);
            if (tour == null)
                throw new Exception("Tour not found");

            tour.Name = updatedTourModel.Name;
            tour.Description = updatedTourModel.Description;
            tour.FromLocation = updatedTourModel.FromLocation;
            tour.ToLocation = updatedTourModel.ToLocation;
            tour.TransportType = updatedTourModel.TransportType;
            tour.Distance = updatedTourModel.Distance;
            tour.EstimatedTime = updatedTourModel.EstimatedTime;
            tour.RouteImagePath = updatedTourModel.RouteImagePath;

            _context.Tours.Update(tour);
            await _context.SaveChangesAsync();

            return new TourModel
            {
                Id = tour.Id,
                Name = tour.Name,
                Description = tour.Description,
                FromLocation = tour.FromLocation,
                ToLocation = tour.ToLocation,
                TransportType = tour.TransportType,
                Distance = tour.Distance,
                EstimatedTime = tour.EstimatedTime,
                RouteImagePath = tour.RouteImagePath
            };
        }

        public async Task DeleteTourAsync(Guid tourModelId)
        {
            var tour = await _context.Tours.FindAsync(tourModelId);
            if (tour == null)
                throw new Exception("Tour not found");

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
        }


    
        //public async Task HandleSubmit()
        //{
            

        //    try
        //    {
        //        if (newTour == null)
        //        {
        //            Console.Error.WriteLine("tourModel is null");
        //            return;
        //        }
        //        newTour.ToLocation = "To";
        //        newTour.FromLocation = "From";
        //        newTour.RouteImagePath = "ssd";
        //        newTour.Description = "ddsddsd";
        //        Console.WriteLine($"Name: {newTour.Name}");


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Error.WriteLine("Failed to create tour: " + ex.Message);
        //    }
        //}
    }
}