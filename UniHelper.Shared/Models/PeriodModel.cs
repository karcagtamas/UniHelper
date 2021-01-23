using System;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Shared.Models
{
    public class PeriodModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        public bool IsCurrent { get; set; }
        
        [Required]
        public DateTime Start { get; set; }
        
        [Required]
        public DateTime End { get; set; } 
    }
}