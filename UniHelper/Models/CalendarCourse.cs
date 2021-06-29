namespace UniHelper.Models
{
    /// <summary>
    /// Calendar Course
    /// </summary>
    public class CalendarCourse
    {
        /// <summary>
        /// Course Id
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Course Place
        /// </summary>
        public string Place { get; set; } = "";

        /// <summary>
        /// Intervall
        /// </summary>
        public string Interval { get; set; } = "";
    }
}