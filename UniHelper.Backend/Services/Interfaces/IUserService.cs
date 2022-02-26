using KarcagS.Common.Tools.Repository;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services.Interfaces;

/// <summary>
/// User Service
/// </summary>
public interface IUserService : IMapperRepository<User, int>
{
    /// <summary>
    /// Get User by Name
    /// </summary>
    /// <param name="username">User name</param>
    /// <returns>User</returns>
    User GetByName(string username);
}
