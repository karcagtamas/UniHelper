using System.Linq;
using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using Microsoft.EntityFrameworkCore;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc cref="UniHelper.Backend.Services.IUserService" />
    public class UserService : Repository<User>, IUserService
    {
        /// <summary>
        /// Init User service
        /// </summary>
        /// <param name="context">Database Context</param>
        /// <param name="logger">Logger Service</param>
        /// <param name="utils">Utils Service</param>
        /// <param name="mapper">Mapper</param>
        public UserService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper) : base(context, logger, utils, mapper, "User")
        {
        }

        /// <inheritdoc />
        public User GetByName(string username)
        {
            return GetList(x => x.UserName.Equals(username)).FirstOrDefault();
        }
    }
}