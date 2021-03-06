using System;
using AutoMapper;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Enums;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Mappers
{
    /// <summary>
    /// Course Mapper
    /// </summary>
    public class CourseMapper : Profile
    {
        /// <summary>
        /// Init Course Mapper
        /// </summary>
        public CourseMapper()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (CourseType) src.Type))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => (DayOfWeek) src.Day))
                .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers))
                .ForMember(dest => dest.IsSelected, opt => opt.MapFrom(src => src.IsSelected))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.Subject.Id));

            CreateMap<CourseModel, Course>()
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int) src.Type))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => (int) src.Day))
                .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers))
                .ForMember(dest => dest.IsSelected, opt => opt.MapFrom(src => src.IsSelected))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId));
        }
    }
}