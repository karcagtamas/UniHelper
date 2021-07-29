using System;
using System.Text.Json.Serialization;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.DTOs
{
    /// <summary>
    /// Course DTO
    /// </summary>
    public class CourseDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Course Place
        /// </summary>
        public string Place { get; set; } = "";
        
        /// <summary>
        /// Type
        /// </summary>
        public CourseType Type { get; set; }
        
        /// <summary>
        /// Start number
        /// </summary>
        public int Number { get; set; }
        
        /// <summary>
        /// Length of course
        /// </summary>
        public int Length { get; set; }
        
        /// <summary>
        /// Day
        /// </summary>
        public DayOfWeek Day { get; set; }
        
        /// <summary>
        /// List of teachers
        /// </summary>
        public string Teachers { get; set; } = "";
        
        /// <summary>
        /// Course Is Selected
        /// </summary>
        public bool IsSelected { get; set; }
        
        /// <summary>
        /// Parent Subject Id
        /// </summary>
        public int SubjectId { get; set; }
    }
}