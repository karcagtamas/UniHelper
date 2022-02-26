using System.ComponentModel.DataAnnotations;

namespace UniHelper.Backend.Entities;

/// <inheritdoc />
public class GlobalTask : Task
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
