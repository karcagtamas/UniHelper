using System;
using System.ComponentModel.DataAnnotations;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.Models
{
    public class TaskModel
    {
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
        
        [Required]
        public DateTime DueDate { get; set; }
        
        [Required]
        public TaskPriority Priority { get; set; }
        
        [Required]
        public bool IsSolved { get; set; }
    }
}