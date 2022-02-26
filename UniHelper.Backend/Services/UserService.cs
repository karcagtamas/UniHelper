using System.Linq;
using AutoMapper;
using KarcagS.Common.Tools.Repository;
using KarcagS.Common.Tools.Services;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services.Interfaces;

namespace UniHelper.Backend.Services;

/// <inheritdoc cref="Interfaces.IUserService" />
public class UserService : MapperRepository<User, int>, IUserService
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
