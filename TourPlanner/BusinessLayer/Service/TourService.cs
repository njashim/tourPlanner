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

        public async Task CreateTourAsync(TourModel newTourModel)
        {
            var tour = _mapper.Map<Tour>(newTourModel);
            await _tourRepository.CreateTourAsync(tour);
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
            var existingTour = _tourRepository.GetTourById(updatedTourModel.Id);

            if (existingTour != null)
            {
                existingTour.FromLocation = updatedTourModel.FromLocation;
                existingTour.ToLocation = updatedTourModel.ToLocation;
                existingTour.TransportType = updatedTourModel.TransportType;
                existingTour.Name = updatedTourModel.Name;
                existingTour.Description = updatedTourModel.Description;
                //Alle Attrivute hinzufuegen evt umaendern auf Repo - Nahi weiß Bescheid

                await _tourRepository.UpdateTourAsync(existingTour);

                var updatedTourModelResult = _mapper.Map<TourModel>(existingTour);

                return updatedTourModelResult;
            }
            else
            {

                var tour = _mapper.Map<Tour>(updatedTourModel);
                tour.RouteImagePath = "test"; // Setze RouteImagePath auf "test"
                var updatedTour = await _tourRepository.UpdateTourAsync(tour);
                var tourModel = _mapper.Map<TourModel>(updatedTour);

                return tourModel;
            }
        }



        public async Task DeleteTourAsync(Guid tourModelId)
        {
            await _tourRepository.DeleteTourAsync(tourModelId);
        }
    
        //public async Task HandleSubmit()
        //{
            

        //    try
        //    {
        //        if (newTour == null)
        //        {
        //            Console.Error.WriteLine("tourModel is null");
        //            return;
        //        }
        //        newTour.ToLocation = "To";
        //        newTour.FromLocation = "From";
        //        newTour.RouteImagePath = "ssd";
        //        newTour.Description = "ddsddsd";
        //        Console.WriteLine($"Name: {newTour.Name}");


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Error.WriteLine("Failed to create tour: " + ex.Message);
        //    }
        //}
    }
}