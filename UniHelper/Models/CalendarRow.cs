using System;
using System.Collections.Generic;
using UniHelper.Shared.DTOs;

namespace UniHelper.Models
{
    /// <summary>
    /// Calendar Header Data
    /// </summary>
    public class CalendarHeaderData
    {
        /// <summary>
        /// Day data
        /// </summary>
        /// <value>Day of the week</value>
        public DayOfWeek Day { get; set; }

        /// <summary>
        /// Colspan need for displaying
        /// </summary>
        /// <value>True if has</value>
        public bool HasColSpan { get; set; }
        
        /// <summary>
        /// Number of colspan Columns
        /// </summary>
        /// <value>Number</value>
        public int ColSpanNumber { get; set; }
        
        /// <summary>
        /// Display tile
        /// </summary>
        /// <value>Display if true</value>
        public bool DoTile { get; set; } = true;
    }
    
    /// <summary>
    /// Calendar Row
    /// </summary>
    public class CalendarRow
    {
        /// <summary>
        /// Lesson Hour
        /// </summary>
        /// <value>Row header</value>
        public LessonHourDto LessonHour { get; set; }
        
        /// <summary>
        /// Row cells
        /// </summary>
        /// <value>Calendar cell list</value>
        public List<CalendarCell> Cells { get; set; }
    }

    /// <summary>
    /// Calendar Cell
    /// </summary>
    public class CalendarCell
    {
        /// <summary>
        /// Day of the cell
        /// </summary>
        /// <value>Day of week</value>
        public DayOfWeek Day { get; set; }
        
        /// <summary>
        /// Tile data
        /// </summary>
        /// <value>Tile object</value>
        public TileDto Tile { get; set; }
        
        /// <summary>
        /// Has row span
        /// </summary>
        /// <value>True if has</value>
        public bool HasRowSpan { get; set; }
        
        /// <summary>
        /// Row span number
        /// </summary>
        /// <value>Number</value>
        public int RowSpanNumber { get; set; }

        /// <summary>
        /// Display tile
        /// </summary>
        /// <value>True if display</value>
        public bool DoTile { get; set; } = true;

        /// <summary>
        /// Has any value
        /// </summary>
        /// <value>True if has</value>
        public bool HasValue { get; set; }
        
        /// <summary>
        /// Cell is hovered
        /// </summary>
        /// <value>True if hovered</value>
        public bool IsHovered { get; set; }
    }
}