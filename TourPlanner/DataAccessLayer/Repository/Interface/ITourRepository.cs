using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interface
{
    public interface ITourRepository
    {
        Task<Tour> CreateTourAsync(Tour newTour);

        Task<List<Tour>> GetToursAsync();

        Tour? GetTourById(Guid tourId);

        Task<Tour> UpdateTourAsync(Tour updatedTour);

        Task DeleteTourAsync(Guid tourId);
    }
}
