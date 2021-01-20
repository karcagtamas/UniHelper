using System;
using System.ComponentModel.DataAnnotations;
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
        public DateTime Start { get; set; }
        
        [Required]
        public DateTime End { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Day { get; set; }
        
        public string Teachers { get; set; }
        
        public bool IsSelected { get; set; }
        
        [Required]
        public string SubjectId { get; set; }
        
        public virtual Subject Subject { get; set; }
    }
}