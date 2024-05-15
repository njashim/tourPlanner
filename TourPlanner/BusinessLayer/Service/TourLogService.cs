using AutoMapper;
using BusinessLayer.Service.Interface;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interface;
using Model;

namespace BusinessLayer.Service
{
    public class TourLogService : ITourLogService
    {
        private readonly IMapper _mapper;
        private readonly ITourLogRepository _tourLogRepository;

        public TourLogService(ITourLogRepository tourLogRepository, IMapper mapper)
        {
            _tourLogRepository = tourLogRepository;
            _mapper = mapper;
        }

        public async Task<TourLogModel> CreateTourLogAsync(TourLogModel newTourLogModel)
        {
            var tourLog = _mapper.Map<TourLog>(newTourLogModel);
            var newTourLog = await _tourLogRepository.CreateTourLogAsync(tourLog);
            var tourLogModel = _mapper.Map<TourLogModel>(newTourLog);

            return tourLogModel;
        }

        public List<TourLogModel> GetTourLogs()
        {
            var tourLogs = _tourLogRepository.GetTourLogs();
            var tourLogsModel = _mapper.Map<List<TourLogModel>>(tourLogs);

            return tourLogsModel;
        }

        public TourLogModel GetTourLogById(Guid tourLogModelId)
        {
            var tourLog = _tourLogRepository.GetTourLogById(tourLogModelId);
            var tourLogModel = _mapper.Map<TourLogModel>(tourLog);

            return tourLogModel;
        }

        public async Task<TourLogModel> UpdateTourLogAsync(TourLogModel updatedTourLogModel)
        {
            var tourLog = _mapper.Map<TourLog>(updatedTourLogModel);
            var updateTourLog = await _tourLogRepository.UpdateTourLogAsync(tourLog);
            var tourLogModel = _mapper.Map<TourLogModel>(updateTourLog);

            return tourLogModel;
        }

        public async Task DeleteTourLogAsync(Guid tourLogModelId)
        {
            await _tourLogRepository.DeleteTourLogAsync(tourLogModelId);
        }
    }
}
