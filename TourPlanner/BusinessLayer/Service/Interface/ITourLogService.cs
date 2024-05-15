using Model;

namespace BusinessLayer.Service.Interface
{
    public interface ITourLogService
    {
        Task<TourLogModel> CreateTourLogAsync(TourLogModel newTourLogModel);

        List<TourLogModel> GetTourLogs();

        TourLogModel GetTourLogById(Guid tourLogModelId);

        Task<TourLogModel> UpdateTourLogAsync(TourLogModel updatedTourLogModel);

        Task DeleteTourLogAsync(Guid tourLogModelId);
    }
}
