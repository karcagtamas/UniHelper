using System;
using System.Text.Json.Serialization;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public CourseType Type { get; set; }
        
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Start { get; set; }
        
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan End { get; set; }
        public DayOfWeek Day { get; set; }
        public string Teachers { get; set; }
        public bool IsSelected { get; set; }
        public int SubjectId { get; set; }
    }
}