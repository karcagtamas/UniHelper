using System;
using System.ComponentModel.DataAnnotations;
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
        public TimeSpan Start { get; set; }
        
        [Required]
        public TimeSpan End { get; set; }
        
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
    }
}