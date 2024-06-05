using DataAccessLayer.Entity;
using DataAccessLayer.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Repository.Interface;

namespace DataAccessLayer.Repository
{
    public class TourLogRepository : ITourLogRepository
    {
        private readonly TourPlannerContext _context;

        public TourLogRepository(TourPlannerContext context)
        {
            _context = context;
        }

        public async Task<TourLog> CreateTourLogAsync(TourLog newTourLog)
        {
            _context.TourLogs.Add(newTourLog);
            await _context.SaveChangesAsync();

            return newTourLog;
        }

        public List<TourLog> GetTourLogs()
        {
            return _context.TourLogs.ToList();
        }

        public TourLog GetTourLogById(Guid tourLogId)
        {
            return _context.TourLogs.Find(tourLogId);
        }

        public async Task<TourLog> UpdateTourLogAsync(TourLog updatedTourLog)
        {
            var existingTourLog = await _context.TourLogs.FindAsync(updatedTourLog.Id);
            if (existingTourLog != null)
            {
                _context.Entry(existingTourLog).CurrentValues.SetValues(updatedTourLog);
                await _context.SaveChangesAsync();
            }
            return existingTourLog;
        }


        public async Task DeleteTourLogAsync(Guid tourLogId)
        {
            var tourLog = await _context.TourLogs.FindAsync(tourLogId);
            if (tourLog != null)
            {
                _context.TourLogs.Remove(tourLog);
                await _context.SaveChangesAsync();
            }
        }
    }
}
