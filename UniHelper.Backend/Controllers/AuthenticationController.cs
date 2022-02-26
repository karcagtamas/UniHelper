using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Services.Interfaces;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers;

/// <summary>
/// Authentication Controller
/// </summary>
[Route("/api/auth")]
[ApiController]
[Authorize]
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
    public void Registration([FromBody] RegistrationModel model)
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
    public StorageUser Login([FromBody] LoginModel model)
    {
        return _authenticationService.Login(model);
    }
}
