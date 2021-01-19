using System;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Backend.Models
{
    public class Course : IEntity
    {
        [Key]
        public string Id { get; set; }
        
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

        public Course()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}