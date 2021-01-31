using System;
using System.Collections.Generic;
using UniHelper.Shared.DTOs;

namespace UniHelper.Models
{
    public class CalendarHeaderData
    {
        public DayOfWeek Day { get; set; }

        public bool HasColSpan { get; set; }
        
        public int ColSpanNumber { get; set; }
        
        public bool DoTile { get; set; } = true;
    }
    
    public class CalendarRow
    {
        public int Number { get; set; }
        
        public List<CalendarCell> Cells { get; set; }
    }

    public class CalendarCell
    {
        public DayOfWeek Day { get; set; }
        
        public TileDto Tile { get; set; }
        
        public bool HasRowSpan { get; set; }
        
        public int RowSpanNumber { get; set; }

        public bool DoTile { get; set; } = true;
    }
}