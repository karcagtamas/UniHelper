using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Karcags.Common.Tools;

namespace UniHelper.Backend.Entities
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(80)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime Registration { get; set; }

        [Required]
        public DateTime LastLogin { get; set; }

        public virtual ICollection<GlobalTask> Tasks { get; set; }
        public virtual ICollection<GlobalNote> Notes { get; set; }
        public virtual ICollection<Period> Periods { get; set; }
    }
}