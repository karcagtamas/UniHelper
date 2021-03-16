using Karcags.Common.Tools;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    /// <summary>
    /// User Service
    /// </summary>
    public interface IUserService : IRepository<User>
    {
        /// <summary>
        /// Get User by Name
        /// </summary>
        /// <param name="username">User name</param>
        /// <returns>User</returns>
        User GetByName(string username);
    }
}