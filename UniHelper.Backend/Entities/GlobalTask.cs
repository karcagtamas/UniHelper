using System.ComponentModel.DataAnnotations;

namespace UniHelper.Backend.Entities
{
    /// <inheritdoc />
    public class GlobalTask : Task
    {
        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}