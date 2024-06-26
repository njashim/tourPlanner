using DataAccessLayer.Entity;
using DataAccessLayer.Entity.Context;
using DataAccessLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace DataAccessLayer.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly TourPlannerContext _context;
        private static readonly ILog log = LogManager.GetLogger(typeof(TourRepository));

        public TourRepository(TourPlannerContext context)
        {
            log.Info("Konstruktor start");
            _context = context;
        }

        public async Task CreateTourAsync(Tour newTour)
        {
            log.Info("CreateTourAsync gestartet");
            _context.Tours.Add(newTour);
            await _context.SaveChangesAsync();
        }

        public List<Tour> GetTours()
        {
            log.Info("GetTours gestartet");
            return _context.Tours.ToList();
        }

        public Tour GetTourById(Guid tourId)
        {
            log.Info("GetTourById gestartet");
            return _context.Tours.Find(tourId);
        }

        public async Task<Tour> UpdateTourAsync(Tour updatedTour)
        {
            log.Info("UpdateTourAsync gestartet");
            _context.Tours.Update(updatedTour);
            await _context.SaveChangesAsync();

            return updatedTour;
        }

        public async Task DeleteTourAsync(Guid tourId)
        {
            log.Info("DeleteTourAsync gestartet");
            var tour = await _context.Tours.FindAsync(tourId);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
            }
        }

    }
}
