﻿using Model;

namespace BusinessLayer.Service.Interface
{
    public interface ITourService
    {
        Task<TourModel> CreateTourAsync(TourModel newTourModel);

        List<TourModel> GetTours();

        TourModel GetTourById(Guid tourModelId);

        Task<TourModel> UpdateTourAsync(TourModel updatedTourModel);

        Task DeleteTourAsync(Guid tourModelId);
    }
}
