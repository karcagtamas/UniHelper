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
        protected UserService(DbContext context, ILoggerService logger, IUtilsService utils, IMapper mapper) : base(context, logger, utils, mapper, "User")
        {
        }

        /// <inheritdoc />
        public void Login()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void Registration()
        {
            throw new System.NotImplementedException();
        }
    }
}