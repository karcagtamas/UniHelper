
using System;
using System.ComponentModel.DataAnnotations;
using Karcags.Common.Tools;

namespace UniHelper.Backend.Entities
{
    /// <summary>
    /// Lesson Hour
    /// </summary>
    public class LessonHour : IEntity
    {
        /// <summary>
        /// Lesson Hour Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Hour Row Number
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// Start time
        /// </summary>
        [Required]
        public TimeSpan Start { get; set; }
        
        /// <summary>
        /// End time
        /// </summary>
        [Required]
        public TimeSpan End { get; set; }
    }
}