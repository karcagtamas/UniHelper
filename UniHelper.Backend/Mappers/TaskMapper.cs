using AutoMapper;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Enums;
using UniHelper.Backend.Models;

namespace UniHelper.Backend.Mappers
{
    public class TaskMapper : Profile
    {
        public TaskMapper()
        {
            this.CreateMap<GlobalTask, TaskDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (TaskPriority) src.Priority))
                .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved));

            this.CreateMap<PeriodTask, TaskDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (TaskPriority) src.Priority))
                .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved));

            this.CreateMap<SubjectTask, TaskDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (TaskPriority) src.Priority))
                .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved));

            this.CreateMap<GlobalTaskModel, GlobalTask>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (int) src.Priority))
                .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved));

            this.CreateMap<PeriodTaskModel, PeriodTask>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (int) src.Priority))
                .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved))
                .ForMember(dest => dest.PeriodId, opt => opt.MapFrom(src => src.PeriodId));

            this.CreateMap<SubjectTaskModel, SubjectTask>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (int) src.Priority))
                .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId));
        }
    }
}