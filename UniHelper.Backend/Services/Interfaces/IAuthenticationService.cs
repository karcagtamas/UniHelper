using UniHelper.Backend.Entities;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Services.Interfaces;

/// <summary>
/// Authentication Service
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Login
    /// </summary>
    /// <returns>Token</returns>
    StorageUser Login(LoginModel model);

    /// <summary>
    /// Registration
    /// </summary>
    void Registration(RegistrationModel model);

    /// <summary>
    /// Token generate
    /// </summary>
    /// <param name="user">Logged in user</param>
    /// <returns>Token</returns>
    string Token(User user);
}
