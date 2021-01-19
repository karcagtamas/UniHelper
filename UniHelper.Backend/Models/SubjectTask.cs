using System.ComponentModel.DataAnnotations;

namespace UniHelper.Backend.Models
{
    /// <summary>
    /// Subject Task entity
    /// </summary>
    public class SubjectTask : Task
    {
        /// <value>
        /// Subject Id
        /// </value>
        [Required]
        public string SubjectId { get; set; }
        
        /// <value>
        /// Subject
        /// </value>
        public virtual Subject Subject { get; set; }
    }
}