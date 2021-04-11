using System.ComponentModel.DataAnnotations;

namespace UniHelper.Backend.Entities
{
    /// <summary>
    /// Global Note
    /// </summary>
    public class GlobalNote : Note
    {
        /// <summary>
        /// Owner User Id
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Owner User
        /// </summary>
        public virtual User User { get; set; }
    }
}