using AutoMapper;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Enums;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Mappers
{
    /// <summary>
    /// Subject Mapper
    /// </summary>
    public class SubjectMapper : Profile
    {
        /// <summary>
        /// Init Subject Mapper
        /// </summary>
        public SubjectMapper()
        {
            CreateMap<Subject, SubjectDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LongName, opt => opt.MapFrom(src => src.LongName))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Credit, opt => opt.MapFrom(src => src.Credit))
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.PeriodId, opt => opt.MapFrom(src => src.Period.Id))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (SubjectType) src.Type))
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));

            CreateMap<SubjectModel, Subject>()
                .ForMember(dest => dest.LongName, opt => opt.MapFrom(src => src.LongName))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Credit, opt => opt.MapFrom(src => src.Credit))
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.PeriodId, opt => opt.MapFrom(src => src.PeriodId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int) src.Type));
        }
    }
}