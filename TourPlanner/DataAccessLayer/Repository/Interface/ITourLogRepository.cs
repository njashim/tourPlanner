using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interface
{
    public interface ITourLogRepository
    {
        Task<TourLog> CreateTourLogAsync(TourLog newTourLog);

        Task<List<TourLog>> GetTourLogsAsync();

        TourLog? GetTourLogById(Guid tourLogId);

        Task<TourLog> UpdateTourLogAsync(TourLog updatedTourLog);

        Task DeleteTourLogAsync(Guid tourLogId);
    }
}
