using System;
using System.Text.Json.Serialization;

namespace UniHelper.Shared.DTOs
{
    /// <summary>
    /// Lesson Hour DTO
    /// </summary>
    public class LessonHourDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Lesson Number
        /// </summary>
        public int Number { get; set; }
        
        /// <summary>
        /// Start of Lesson
        /// </summary>
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Start { get; set; }
        
        /// <summary>
        /// End of Lesson
        /// </summary>
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan End { get; set; }
    }
}