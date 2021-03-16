using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Services;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    /// <summary>
    /// Authentication Controller
    /// </summary>
    [Route("/api/auth")]
    [ApiController]
    public class AuthenticationController
    {
        private readonly IAuthenticationService _authenticationService;
        
        /// <summary>
        /// Init Authentication Controller
        /// </summary>
        /// <param name="authenticationService"></param>
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Registration
        /// <param name="model">Registration Model</param>
        /// </summary>
        [AllowAnonymous]
        [HttpPost("registration")]
        public void Registration(RegistrationModel model)
        {
            _authenticationService.Registration(model);
        }

        /// <summary>
        /// Login
        /// <param name="model">Login Model</param>
        /// <returns>Token</returns>
        /// </summary>
        [AllowAnonymous]
        [HttpPost("login")]
        public string Login(LoginModel model)
        {
            return _authenticationService.Login(model);
        }

        /// <summary>
        /// Generate Token
        /// </summary>
        /// <returns>Token</returns>
        [AllowAnonymous]
        [HttpGet("token")]
        public string Token()
        {
            return _authenticationService.Token();
        }
    }
}