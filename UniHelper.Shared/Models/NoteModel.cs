using System;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Note Model
    /// </summary>
    public class NoteModel
    {
        /// <summary>
        /// Note
        /// </summary>
        [Required]
        [StringLength(240)]
        public string Text { get; set; } = "";
        
        /// <summary>
        /// Creation
        /// </summary>
        [Required]
        public DateTime Created { get; set; }
        
        /// <summary>
        /// Last Update
        /// </summary>
        [Required]
        public DateTime LastUpdated { get; set; }
        
        /// <summary>
        /// Is Closed
        /// </summary>
        [Required]
        public bool IsClosed { get; set; }
    }
}