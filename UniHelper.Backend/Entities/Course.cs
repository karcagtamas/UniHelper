using System;
using System.ComponentModel.DataAnnotations;
using Karcags.Common.Annotations;
using Karcags.Common.Tools;

namespace UniHelper.Backend.Entities
{
    /// <summary>
    /// Course Entity
    /// </summary>
    public class Course : IEntity
    {
        /// <summary>
        /// Course Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Place
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Place { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [Required]
        [MinNumber(0)]
        public int Type { get; set; }

        /// <summary>
        /// Row Number
        /// </summary>
        [Required]
        [MinNumber(0)]
        [MaxNumber(16)]
        public int Number { get; set; }

        /// <summary>
        /// Row Length
        /// </summary>
        [Required]
        [MinNumber(1)]
        [MaxNumber(8)]
        public int Length { get; set; }

        /// <summary>
        /// Day
        /// </summary>
        [Required]
        [MinNumber(0)]
        [MaxNumber(6)]
        public int Day { get; set; }

        /// <summary>
        /// Teachers
        /// </summary>
        public string Teachers { get; set; }

        /// <summary>
        /// Course is Selected (Active)
        /// </summary>
        [Required]
        public bool IsSelected { get; set; }

        /// <summary>
        /// Parent Subject Id
        /// </summary>
        [Required]
        public int SubjectId { get; set; }

        /// <summary>
        /// Parent Subject
        /// </summary>
        public virtual Subject Subject { get; set; }
    }
}