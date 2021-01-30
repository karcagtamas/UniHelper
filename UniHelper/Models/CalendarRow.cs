using System;
using System.Collections.Generic;
using UniHelper.Shared.DTOs;

namespace UniHelper.Models
{
    public class CalendarRow
    {
        public int Number { get; set; }
        
        public List<CalendarCell> Cells { get; set; }
    }

    public class CalendarCell
    {
        public DayOfWeek Day { get; set; }
        
        public TileDto Tile { get; set; }
    }
}