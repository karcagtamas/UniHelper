using System;
using System.ComponentModel.DataAnnotations;
using Karcags.Common.Tools;

namespace UniHelper.Backend.Entities
{
    /// <summary>
    /// Note base class
    /// </summary>
    public class Note : IEntity
    {
        /// <value>
        /// Note Id
        /// </value>
        [Key]
        public int Id { get; set; }
        
        /// <value>
        /// Note Text
        /// </value>
        [Required]
        [StringLength(240)]
        public string Text { get; set; }
        
        /// <value>
        /// Note Creation date
        /// </value>
        [Required]
        public DateTime Created { get; set; }
        
        /// <value>
        /// Note Last update date
        /// </value>
        [Required]
        public DateTime LastUpdated { get; set; }
        
        /// <value>
        /// Note Is closed status
        /// </value>
        [Required]
        public bool IsClosed { get; set; }
    }
}