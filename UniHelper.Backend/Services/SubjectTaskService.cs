using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc cref="UniHelper.Backend.Services.ISubjectTaskService" />
    public class SubjectTaskService : Repository<SubjectTask>, ISubjectTaskService
    {
        /// <summary>
        /// Init Subject Task Service
        /// </summary>
        /// <param name="context">Database Context</param>
        /// <param name="logger">Logger</param>
        /// <param name="utils">Utils Service</param>
        /// <param name="mapper">Mapper</param>
        public SubjectTaskService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper) : base(context, logger, utils, mapper, "Subject Task")
        {
        }
    }
}