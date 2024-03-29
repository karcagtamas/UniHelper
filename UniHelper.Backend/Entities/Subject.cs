using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Karcags.Common.Tools;
using UniHelper.Shared;

namespace UniHelper.Backend.Entities
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
        public int Id { get; set; }
        
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
        [StringLength(16)]
        public string Code { get; set; }
        
        /// <value>
        /// Subject description
        /// </value>
        public string Description { get; set; }
        
        /// <value>
        /// Subject credit value
        /// </value>
        [Required]
        [MaxNumber(10)]
        [MinNumber(0)]
        public int Credit { get; set; }

        /// <value>
        /// Period Id
        /// </value>
        [Required]
        public int PeriodId { get; set; }
        
        /// <value>
        /// Result mark of subject
        /// </value>
        [MinNumber(1)]
        [MaxNumber(5)]
        public int? Result { get; set; }
        
        /// <value>
        /// Is active
        /// </value>
        [Required]
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Subject Type
        /// </summary>
        [Required]
        public int Type { get; set; }
        
        /// <value>
        /// Period
        /// </value>
        public virtual Period Period { get; set; }
        
        /// <value>
        /// Subject tasks
        /// </value>
        public virtual ICollection<SubjectTask> Tasks { get; set; }
        
        /// <value>
        /// Subject courses
        /// </value>
        public virtual ICollection<Course> Courses { get; set; }
    }
}