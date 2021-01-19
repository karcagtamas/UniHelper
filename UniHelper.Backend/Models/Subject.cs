using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Backend.Models
{
    /// <summary>
    /// Subject Entity
    /// </summary>
    public class Subject : IEntity
    {
        /// <value>
        /// Subject Id
        /// </value>
        [Key]
        public string Id { get; set; }
        
        /// <value>
        /// Subject long name
        /// </value>
        [Required]
        [StringLength(100)]
        public string LongName { get; set; }
        
        /// <value>
        /// Subject short name
        /// </value>
        [Required]
        [StringLength(20)]
        public string ShortName { get; set; }
        
        /// <value>
        /// Subject code
        /// </value>
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        
        /// <value>
        /// Subject description
        /// </value>
        public string Description { get; set; }
        
        /// <value>
        /// Subject credit value
        /// </value>
        [Required]
        public int Credit { get; set; }

        /// <value>
        /// Subject folder name
        /// </value>
        [Required]
        [StringLength(20)]
        public string FolderName { get; set; }
        
        /// <value>
        /// Period Id
        /// </value>
        [Required]
        public string PeriodId { get; set; }
        
        /// <value>
        /// Result mark of subject
        /// </value>
        public int? Result { get; set; }
        
        /// <value>
        /// Is active
        /// </value>
        public bool IsActive { get; set; }
        
        /// <value>
        /// Period
        /// </value>
        public virtual Period Period { get; set; }

        /// <value>
        /// Subject notes
        /// </value>
        public virtual ICollection<SubjectNote> Notes { get; set; }
        
        /// <value>
        /// Subject tasks
        /// </value>
        public virtual ICollection<SubjectTask> Tasks { get; set; }
        
        /// <value>
        /// Subject courses
        /// </value>
        public virtual ICollection<Course> Courses { get; set; }

        /// <summary>
        /// Initialize Subject Entity
        /// </summary>
        public Subject()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}