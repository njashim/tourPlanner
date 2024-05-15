using DataAccessLayer.Entity;
using Model;

namespace BusinessLayer.Service.Interface
{
    public interface ITourService
    {

        List<Tour> Tours { get; set; }
        Tour? newTour { get; set; }

       


        List<TourModel> GetTours();

        TourModel GetTourById(Guid tourModelId);

        Task<TourModel> UpdateTourAsync(TourModel updatedTourModel);

        Task DeleteTourAsync(Guid tourModelId);

        Task CreateTourAsync();
    }
}
