using System;
using System.ComponentModel.DataAnnotations;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.Models
{
    public class CourseModel
    {
        [Required]
        [MaxLength(20)]
        public string Place { get; set; }
        
        [Required]
        public CourseType Type { get; set; }
        
        [Required]
        public int Number { get; set; }
        
        [Required]
        public int Length { get; set; }
        
        [Required]
        public DayOfWeek Day { get; set; }
        public string Teachers { get; set; }
        
        [Required]
        public bool IsSelected { get; set; }
        
        [Required]
        public int SubjectId { get; set; }

        public CourseModel()
        {
            IsSelected = true;
        }

        public CourseModel(int subjectId)
        {
            SubjectId = subjectId;
            IsSelected = true;
        }

        public CourseModel(CourseDto dto)
        {
            Place = dto.Place;
            Type = dto.Type;
            Number = dto.Number;
            Length = dto.Length;
            Day = dto.Day;
            Teachers = dto.Teachers;
            IsSelected = dto.IsSelected;
            SubjectId = dto.SubjectId;
        }
    }
}