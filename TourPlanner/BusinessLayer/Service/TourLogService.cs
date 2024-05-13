using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class TourLogService
    {
        private readonly TourLogRepository _tourLogRepository;

        public TourLogService(TourLogRepository tourLogRepository)
        {
            _tourLogRepository = tourLogRepository;
        }

        public async Task<TourLog> CreateTourLogAsync(TourLog newTourLog)
        {
            return await _tourLogRepository.CreateTourLogAsync(newTourLog);
        }

        public async Task<List<TourLog>> GetTourLogsAsync()
        {
            return await _tourLogRepository.GetTourLogsAsync();
        }

        public async Task<TourLog> GetTourLogByIdAsync(int tourLogId)
        {
            return await _tourLogRepository.GetTourLogByIdAsync(tourLogId);
        }

        public async Task<TourLog> UpdateTourLogAsync(TourLog updatedTourLog)
        {
            return await _tourLogRepository.UpdateTourLogAsync(updatedTourLog);
        }

        public async Task DeleteTourLogAsync(int tourLogId)
        {
            await _tourLogRepository.DeleteTourLogAsync(tourLogId);
        }
    }
}
