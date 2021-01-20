using AutoMapper;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Enums;
using UniHelper.Backend.Models;

namespace UniHelper.Backend.Mappers
{
    public class SubjectMapper : Profile
    {
        public SubjectMapper()
        {
            this.CreateMap<Subject, SubjectDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LongName, opt => opt.MapFrom(src => src.LongName))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Credit, opt => opt.MapFrom(src => src.Credit))
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.PeriodId, opt => opt.MapFrom(src => src.Period.Id))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (SubjectType)src.Type))
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));

            this.CreateMap<SubjectModel, Subject>()
                .ForMember(dest => dest.LongName, opt => opt.MapFrom(src => src.LongName))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Credit, opt => opt.MapFrom(src => src.Credit))
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.PeriodId, opt => opt.MapFrom(src => src.PeriodId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type));
        }
    }
}