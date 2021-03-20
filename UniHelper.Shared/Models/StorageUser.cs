namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Local Storage User
    /// </summary>
    public class StorageUser
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Full Name
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }
}