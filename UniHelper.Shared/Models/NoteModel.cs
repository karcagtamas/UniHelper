using System;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Shared.Models
{
    public class NoteModel
    {
        [Required]
        [StringLength(240)]
        public string Text { get; set; }
        
        [Required]
        public DateTime Created { get; set; }
        
        [Required]
        public DateTime LastUpdated { get; set; }
        
        [Required]
        public bool IsClosed { get; set; }
    }
}