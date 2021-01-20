using System;
using AutoMapper;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Enums;
using UniHelper.Backend.Models;

namespace UniHelper.Backend.Mappers
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            this.CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (CourseType)src.Type))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => (DayOfWeek)src.Day))
                .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers))
                .ForMember(dest => dest.IsSelected, opt => opt.MapFrom(src => src.IsSelected))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.Subject.Id));
            
            this.CreateMap<CourseModel, Course>()
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => (int)src.Day))
                .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers))
                .ForMember(dest => dest.IsSelected, opt => opt.MapFrom(src => src.IsSelected))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId));
        }
    }
}