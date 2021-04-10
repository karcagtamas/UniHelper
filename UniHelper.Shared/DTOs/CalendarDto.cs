using System;
using System.Collections.Generic;

namespace UniHelper.Shared.DTOs
{
    /// <summary>
    /// Calendar DTO
    /// </summary>
    public class CalendarDto
    {
        /// <summary>
        /// Period ID
        /// </summary>
        public int PeriodId { get; set; }
        
        /// <summary>
        /// Period Name
        /// </summary>
        public string PeriodName { get; set; }
        
        /// <summary>
        /// List of days
        /// </summary>
        public List<DayDto> Days { get; set; }

        /// <summary>
        /// Init Calendar DTO
        /// </summary>
        public CalendarDto()
        {
            Days = new List<DayDto>();
        }
    }

    /// <summary>
    /// Day DTO
    /// </summary>
    public class DayDto
    {
        /// <summary>
        /// Day of the week
        /// </summary>
        public DayOfWeek DayOfWeek { get; set; }
        
        /// <summary>
        /// Day tiles for lessons
        /// </summary>
        public List<TileDto> Tiles { get; set; }
    }

    /// <summary>
    /// Tile DTO
    /// </summary>
    public class TileDto
    {
        /// <summary>
        /// Course Id
        /// </summary>
        public int CourseId { get; set; }
        
        /// <summary>
        /// Course Place
        /// </summary>
        public string Place { get; set; }
        
        /// <summary>
        /// Parent Subject Id
        /// </summary>
        public int SubjectId { get; set; }
        
        /// <summary>
        /// Subject Short Name
        /// </summary>
        public string SubjectShortName { get; set; }
        
        /// <summary>
        /// Subject Long Name
        /// </summary>
        public string SubjectLongName { get; set; }
        
        /// <summary>
        /// Start number
        /// </summary>
        public int Number { get; set; }
        
        /// <summary>
        /// Length of tile
        /// </summary>
        public int Length { get; set; }
    }
}