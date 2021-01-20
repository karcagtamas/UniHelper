using System;

namespace UniHelper.Backend.Models
{
    public class PeriodModel
    {
        public string Name { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; } 
    }
}