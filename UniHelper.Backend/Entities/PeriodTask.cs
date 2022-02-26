using System.ComponentModel.DataAnnotations;

namespace UniHelper.Backend.Entities;

/// <summary>
/// Period Task entity
/// </summary>
public class PeriodTask : Task
{
    /// <value>
    /// Period Id
    /// </value>
    [Required]
    public int PeriodId { get; set; }
    
    /// <value>
    /// Period
    /// </value>
    public virtual Period Period { get; set; }
}
