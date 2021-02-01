using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniHelper.Shared.Models
{
    public class LessonHourModel
    {
        [Required]
        public int Number { get; set; }

        [Required]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Start { get; set; }
        
        [Required]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan End { get; set; }
    }
}