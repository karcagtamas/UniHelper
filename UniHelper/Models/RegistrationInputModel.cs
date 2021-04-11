using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Models
{
    /// <summary>
    /// Registration Input Model
    /// </summary>
    public class RegistrationInputModel
    {
        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        [MaxLength(80)]
        public string UserName { get; set; }
        
        /// <summary>
        /// Full Name
        /// </summary>
        [Required]
        [MaxLength(120)]
        public string FullName { get; set; }
        
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        public string Password { get; set; }
        
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
        
        /// <summary>
        /// Email Address
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}