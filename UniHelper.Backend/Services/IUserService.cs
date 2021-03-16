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
        /// Login
        /// </summary>
        void Login();

        /// <summary>
        /// Registration
        /// </summary>
        void Registration();
    }
}