using AutoMapper;
using DataAccessLayer.Entity;
using Model;

namespace BusinessLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tour, TourModel>();
            CreateMap<TourLog, TourLogModel>();

            CreateMap<TourModel, Tour>();
            CreateMap<TourLogModel, TourLog>();
        }
    }
}
