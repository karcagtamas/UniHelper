using System.Threading.Tasks;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model">Login Model</param>
        /// <returns>Token</returns>
        Task<bool> Login(LoginModel model);

        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="model">Registration Model</param>
        /// <returns>It was success or not</returns>
        Task<bool> Registration(RegistrationModel model);
    }
}