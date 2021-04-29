using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Karcags.Common.Tools;
using UniHelper.Shared;

namespace UniHelper.Backend.Entities
{
    /// <summary>
    /// Period Entity
    /// </summary>
    public class Period : IEntity
    {
        /// <summary>
        /// Period Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Period display name
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Is current Period
        /// </summary>
        [Required]
        public bool IsCurrent { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        [Required]
        [DateAfter("Start")]
        public DateTime End { get; set; }

        /// <summary>
        /// Owner User Id
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Subjects
        /// </summary>
        public virtual ICollection<Subject> Subjects { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public virtual ICollection<PeriodNote> Notes { get; set; }

        /// <summary>
        /// Tasks
        /// </summary>
        public virtual ICollection<PeriodTask> Tasks { get; set; }

        /// <summary>
        /// Owner User
        /// </summary>
        public virtual User User { get; set; }
    }
}