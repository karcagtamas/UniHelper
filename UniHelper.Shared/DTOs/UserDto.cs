using System;

namespace UniHelper.Shared.DTOs
{
    /// <summary>
    /// User DTO
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Full Name
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// E-mail Address
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Registration
        /// </summary>
        public DateTime Registration { get; set; }
        
        /// <summary>
        /// Last Login
        /// </summary>
        public DateTime LastLogin { get; set; }
    }
}