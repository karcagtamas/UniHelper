using System.ComponentModel.DataAnnotations;

namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Registration Model
    /// </summary>
    public class RegistrationModel
    {
        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        [MaxLength(80)]
        public string UserName { get; set; } = "";
        
        /// <summary>
        /// Full Name
        /// </summary>
        [Required]
        [MaxLength(120)]
        public string FullName { get; set; } = "";
        
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        public string Password { get; set; } = "";
        
        /// <summary>
        /// Email Address
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
    }
}