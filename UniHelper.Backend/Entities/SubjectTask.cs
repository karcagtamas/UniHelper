using System.ComponentModel.DataAnnotations;

namespace UniHelper.Backend.Entities
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
        public int SubjectId { get; set; }
        
        /// <value>
        /// Subject
        /// </value>
        public virtual Subject Subject { get; set; }
    }
}