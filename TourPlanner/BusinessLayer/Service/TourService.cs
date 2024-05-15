using AutoMapper;
using BusinessLayer.Service.Interface;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interface;
using Model;

namespace BusinessLayer.Service
{
    public class TourService : ITourService
    {
        private readonly IMapper _mapper;
        private readonly ITourRepository _tourRepository;

        public TourService(ITourRepository tourRepository, IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        public async Task<TourModel> CreateTourAsync(TourModel newTourModel)
        {
            var tour = _mapper.Map<Tour>(newTourModel);
            var newTour = await _tourRepository.CreateTourAsync(tour);
            var tourModel = _mapper.Map<TourModel>(newTour);

            return tourModel;
        }

        public List<TourModel> GetTours()
        {
            var tours = _tourRepository.GetTours();
            var toursModel = _mapper.Map<List<TourModel>>(tours);

            return toursModel;
        }

        public TourModel GetTourById(Guid tourModelId)
        {
            var tour = _tourRepository.GetTourById(tourModelId);
            var tourModel = _mapper.Map<TourModel>(tour);

            return tourModel;
        }

        public async Task<TourModel> UpdateTourAsync(TourModel updatedTourModel)
        {
            var tour = _mapper.Map<Tour>(updatedTourModel);
            var updatedTour = await _tourRepository.UpdateTourAsync(tour);
            var tourModel = _mapper.Map<TourModel>(updatedTour);

            return tourModel;
        }

        public async Task DeleteTourAsync(Guid tourModelId)
        {
            await _tourRepository.DeleteTourAsync(tourModelId);
        }
    }
}
