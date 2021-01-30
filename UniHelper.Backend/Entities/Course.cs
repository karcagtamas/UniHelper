using System;
using System.ComponentModel.DataAnnotations;
using Karcags.Common.Annotations;
using Karcags.Common.Tools;

namespace UniHelper.Backend.Entities
{
    public class Course : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Place { get; set; }
        
        [Required]
        [MinNumber(0)]
        public int Type { get; set; }
        
        [Required]
        [MinNumber(0)]
        [MaxNumber(10)]
        public int Number { get; set; }
        
        [Required]
        [MinNumber(1)]
        [MaxNumber(6)]
        public int Length { get; set; }
        
        [Required]
        [MinNumber(0)]
        [MaxNumber(6)]
        public int Day { get; set; }
        
        public string Teachers { get; set; }
        
        [Required]
        public bool IsSelected { get; set; }

        [Required]
        public int SubjectId { get; set; }
        
        public virtual Subject Subject { get; set; }
    }
}