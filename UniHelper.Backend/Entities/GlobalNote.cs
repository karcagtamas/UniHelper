using System.ComponentModel.DataAnnotations;

namespace UniHelper.Backend.Entities
{
    /// <summary>
    /// Global Note
    /// </summary>
    public class GlobalNote : Note
    {
        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}