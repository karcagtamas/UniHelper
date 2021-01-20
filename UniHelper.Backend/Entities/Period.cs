using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Karcags.Common.Tools;

namespace UniHelper.Backend.Entities
{
    public class Period : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        public bool IsCurrent { get; set; }
        
        [Required]
        public DateTime Start { get; set; }
        
        [Required]
        public DateTime End { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<PeriodNote> Notes { get; set; }
        public virtual ICollection<PeriodTask> Tasks { get; set; }
    }
}