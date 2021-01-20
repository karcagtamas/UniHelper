using System;
using System.ComponentModel.DataAnnotations;
using Karcags.Common.Annotations;
using UniHelper.Backend.Enums;

namespace UniHelper.Backend.Models
{
    public class CourseModel
    {
        [Required]
        [MaxLength(20)]
        public string Place { get; set; }
        
        [Required]
        [MinNumber(0)]
        public CourseType Type { get; set; }
        
        [Required]
        public TimeSpan Start { get; set; }
        
        [Required]
        public TimeSpan End { get; set; }
        
        [Required]
        [MinNumber(0)]
        [MaxNumber(6)]
        public DayOfWeek Day { get; set; }
        public string Teachers { get; set; }
        
        [Required]
        public bool IsSelected { get; set; }
        
        [Required]
        public int SubjectId { get; set; }
    }
}