using UniHelper.Shared.Models;

namespace UniHelper.Backend.Services
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <returns>Token</returns>
        string Login(LoginModel model);
        
        /// <summary>
        /// Registration
        /// </summary>
        void Registration(RegistrationModel model);
        
        /// <summary>
        /// Token generate
        /// </summary>
        /// <returns>Token</returns>
        string Token();
    }
}