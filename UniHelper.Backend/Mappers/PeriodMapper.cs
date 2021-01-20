using AutoMapper;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Models;

namespace UniHelper.Backend.Mappers
{
    public class PeriodMapper : Profile
    {
        public PeriodMapper()
        {
            this.CreateMap<Period, PeriodDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            
            this.CreateMap<PeriodModel, Period>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        }
    }
}