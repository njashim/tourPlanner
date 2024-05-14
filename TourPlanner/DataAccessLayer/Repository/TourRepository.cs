using DataAccessLayer.Entity;
using DataAccessLayer.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class TourRepository
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

        public async Task<List<Tour>> GetToursAsync()
        {
            return await _context.Tours.ToListAsync();
        }

        public async Task<Tour> GetTourByIdAsync(int tourId)
        {
            return await _context.Tours.FindAsync(tourId);
        }

        public async Task<Tour> UpdateTourAsync(Tour updatedTour)
        {
            _context.Tours.Update(updatedTour);
            await _context.SaveChangesAsync();

            return updatedTour;
        }

        public async Task DeleteTourAsync(int tourId)
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
