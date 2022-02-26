using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KarcagS.Common.Tools.Entities;

namespace UniHelper.Backend.Entities;

/// <summary>
/// User Entity
/// </summary>
public class User : IEntity<int>
{
    /// <summary>
    /// User Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Full Name
    /// </summary>
    [Required]
    [MaxLength(120)]
    public string FullName { get; set; }

    /// <summary>
    /// User Name
    /// </summary>
    [Required]
    [MaxLength(80)]
    public string UserName { get; set; }

    /// <summary>
    /// Password
    /// </summary>
    [Required]
    public string Password { get; set; }

    /// <summary>
    /// Email Address
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Registration Time
    /// </summary>
    [Required]
    public DateTime Registration { get; set; }

    /// <summary>
    /// Last Login Time
    /// </summary>
    [Required]
    public DateTime LastLogin { get; set; }

    /// <summary>
    /// User Tasks
    /// </summary>
    public virtual ICollection<GlobalTask> Tasks { get; set; }
    
    /// <summary>
    /// User Periods
    /// </summary>
    public virtual ICollection<Period> Periods { get; set; }
}
