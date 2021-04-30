using System;
using System.ComponentModel.DataAnnotations;
using Karcags.Common.Tools;

namespace UniHelper.Backend.Entities
{
    /// <summary>
    /// Task
    /// </summary>
    public class Task : IEntity
    {
        /// <value>
        /// Task Id
        /// </value>
        [Key]
        public int Id { get; set; }
        
        /// <value>
        /// Task text
        /// </value>
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
        
        /// <value>
        /// Task due date
        /// </value>
        [Required]
        public DateTime DueDate { get; set; }
        
        /// <value>
        /// Task priority
        /// </value>
        [Required]
        public int Priority { get; set; }
        
        /// <summary>
        /// Task is solved
        /// </summary>
        [Required]
        public bool IsSolved { get; set; }
    }
}