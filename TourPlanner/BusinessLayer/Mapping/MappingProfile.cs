using AutoMapper;
using DataAccessLayer.Entity;
using Model;

namespace BusinessLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tour, TourModel>().ReverseMap();
            CreateMap<TourLog, TourLogModel>();

            CreateMap<TourLogModel, TourLog>()
                .ForMember(dest => dest.Tour, opt => opt.Ignore());
        }
    }
}
