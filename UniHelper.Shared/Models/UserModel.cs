using System;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Shared.Models
{
    public class UserModel
    {
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
    }
}