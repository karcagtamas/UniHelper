using AutoMapper;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Mappers
{
    /// <summary>
    /// Lesson Hour Mapper
    /// </summary>
    public class LessonHourMapper : Profile
    {
        /// <summary>
        /// Init Lesson Hour Mapper
        /// </summary>
        public LessonHourMapper()
        {
            CreateMap<LessonHour, LessonHourDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End));

            CreateMap<LessonHourModel, LessonHour>()
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End));
        }
    }
}