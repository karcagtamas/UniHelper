using System;
using System.Text.Json.Serialization;

namespace UniHelper.Shared.DTOs
{
    /// <summary>
    /// Lesson Hour Interval DTO
    /// </summary>
    public class LessonHourIntervalDto
    {
        /// <summary>
        /// Start of interval
        /// </summary>
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Start { get; set; }
        
        /// <summary>
        /// End of interval
        /// </summary>
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan End { get; set; }
    }
}