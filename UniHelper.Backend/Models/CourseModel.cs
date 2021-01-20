using System;

namespace UniHelper.Backend.Models
{
    public class CourseModel
    {
        public string Place { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Day { get; set; }
        public string Teachers { get; set; }
        public bool IsSelected { get; set; }
        public int SubjectId { get; set; }
    }
}