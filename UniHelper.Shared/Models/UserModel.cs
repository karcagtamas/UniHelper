using System;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Shared.Models
{
    /// <summary>
    /// User Model
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Full Name
        /// </summary>
        [Required]
        [MaxLength(120)]
        public string FullName { get; set; } = "";

        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        [MaxLength(80)]
        public string UserName { get; set; } = "";

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; } = "";

        /// <summary>
        /// E-mail
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        /// <summary>
        /// Registration
        /// </summary>
        [Required]
        public DateTime Registration { get; set; }

        /// <summary>
        /// Last Login
        /// </summary>
        [Required]
        public DateTime LastLogin { get; set; }
    }
}