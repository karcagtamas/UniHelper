using System;

namespace UniHelper.Backend.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Day { get; set; }
        public string Teachers { get; set; }
        public bool IsSelected { get; set; }
        public int SubjectId { get; set; }
    }
}