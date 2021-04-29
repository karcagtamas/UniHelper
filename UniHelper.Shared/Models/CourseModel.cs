using System;
using System.ComponentModel.DataAnnotations;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Course Model
    /// </summary>
    public class CourseModel
    {
        /// <summary>
        /// Place
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Place { get; set; } = "";
        
        /// <summary>
        /// Type
        /// </summary>
        [Required]
        public CourseType Type { get; set; }
        
        /// <summary>
        /// Number
        /// </summary>
        [Required]
        [MinNumber(0)]
        [MaxNumber(10)]
        public int Number { get; set; }
        
        /// <summary>
        /// Length
        /// </summary>
        [Required]
        [MinNumber(1)]
        [MaxSum(14, "Number")]
        public int Length { get; set; }
        
        /// <summary>
        /// Day
        /// </summary>
        [Required]
        public DayOfWeek Day { get; set; }
        
        /// <summary>
        /// Teachers
        /// </summary>
        public string Teachers { get; set; } = "";
        
        /// <summary>
        /// Is Selected
        /// </summary>
        [Required]
        public bool IsSelected { get; set; }
        
        /// <summary>
        /// Subject Id
        /// </summary>
        [Required]
        public int SubjectId { get; set; }

        /// <summary>
        /// Course Model Init
        /// </summary>
        public CourseModel()
        {
            IsSelected = true;
        }

        /// <summary>
        /// Course Model Init
        /// </summary>
        /// <param name="subjectId">Subject Id</param>
        public CourseModel(int subjectId)
        {
            SubjectId = subjectId;
            IsSelected = true;
        }

        /// <summary>
        /// Course Model Init
        /// </summary>
        /// <param name="dto">Course DTO</param>
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