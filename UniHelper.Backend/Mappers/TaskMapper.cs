using AutoMapper;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Enums;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Mappers;

/// <summary>
/// Task Mapper
/// </summary>
public class TaskMapper : Profile
{
    /// <summary>
    /// Init Task Mapper
    /// </summary>
    public TaskMapper()
    {
        CreateMap<GlobalTask, TaskDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (TaskPriority)src.Priority))
            .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => TaskType.Global))
            .ForMember(dest => dest.DefinitionText, opt => opt.MapFrom(src => ""));

        CreateMap<PeriodTask, TaskDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (TaskPriority)src.Priority))
            .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => TaskType.Period))
            .ForMember(dest => dest.DefinitionText, opt => opt.MapFrom(src => src.Period.Name));

        CreateMap<SubjectTask, TaskDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (TaskPriority)src.Priority))
            .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => TaskType.Subject))
            .ForMember(dest => dest.DefinitionText, opt => opt.MapFrom(src => src.Subject.ShortName));

        CreateMap<GlobalTaskModel, GlobalTask>()
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (int)src.Priority))
            .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<PeriodTaskModel, PeriodTask>()
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (int)src.Priority))
            .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved))
            .ForMember(dest => dest.PeriodId, opt => opt.MapFrom(src => src.PeriodId));

        CreateMap<SubjectTaskModel, SubjectTask>()
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (int)src.Priority))
            .ForMember(dest => dest.IsSolved, opt => opt.MapFrom(src => src.IsSolved))
            .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId));
    }
}
