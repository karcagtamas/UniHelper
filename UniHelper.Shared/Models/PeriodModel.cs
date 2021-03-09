using System;
using System.ComponentModel.DataAnnotations;
using UniHelper.Shared.DTOs;

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
        public DateTime? Start { get; set; }
        
        [Required]
        public DateTime? End { get; set; }
        
        public PeriodModel() {}

        public PeriodModel(PeriodDto dto)
        {
            Name = dto.Name;
            IsCurrent = dto.IsCurrent;
            Start = dto.Start;
            End = dto.End;
        }
    }
}