using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Lesson Hour Model
    /// </summary>
    public class LessonHourModel
    {
        /// <summary>
        /// Lesson Number
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// Lesson Start
        /// </summary>
        [Required]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Start { get; set; }
        
        /// <summary>
        /// Lesson End
        /// </summary>
        [Required]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan End { get; set; }
    }
}