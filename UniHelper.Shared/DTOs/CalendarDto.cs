using System;
using System.Collections.Generic;

namespace UniHelper.Shared.DTOs
{
    public class CalendarDto
    {
        public int PeriodId { get; set; }
        public string PeriodName { get; set; }
        public List<DayDto> Days { get; set; }

        public CalendarDto()
        {
            Days = new List<DayDto>();
        }
    }

    public class DayDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        
        public List<TileDto> Tiles { get; set; }
    }

    public class TileDto
    {
        public int CourseId { get; set; }
        public string Place { get; set; }
        public int SubjectId { get; set; }
        public string SubjectShortName { get; set; }
        public string SubjectLongName { get; set; }
        public int Number { get; set; }
        public int Length { get; set; }
    }
}