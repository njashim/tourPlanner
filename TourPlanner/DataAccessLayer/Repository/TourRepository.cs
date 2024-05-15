using DataAccessLayer.Entity;
using DataAccessLayer.Entity.Context;
using DataAccessLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly TourPlannerContext _context;

        public TourRepository(TourPlannerContext context)
        {
            _context = context;
        }

        public async Task<Tour> CreateTourAsync(Tour newTour)
        {
            _context.Tours.Add(newTour);
            await _context.SaveChangesAsync();

            return newTour;
        }

        public List<Tour> GetTours()
        {
            return _context.Tours.ToList();
        }

        public Tour GetTourById(Guid tourId)
        {
            return _context.Tours.Find(tourId);
        }

        public async Task<Tour> UpdateTourAsync(Tour updatedTour)
        {
            _context.Tours.Update(updatedTour);
            await _context.SaveChangesAsync();

            return updatedTour;
        }

        public async Task DeleteTourAsync(Guid tourId)
        {
            var tour = await _context.Tours.FindAsync(tourId);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
            }
        }
    }
}
