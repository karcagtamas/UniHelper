using System;
using System.Text.Json.Serialization;

namespace UniHelper.Shared.DTOs
{
    public class LessonHourIntervalDto
    {
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Start { get; set; }
        
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan End { get; set; }
    }
}