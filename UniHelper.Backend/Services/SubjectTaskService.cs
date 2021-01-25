using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    public class SubjectTaskService : Repository<SubjectTask>, ISubjectTaskService
    {
        public SubjectTaskService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper) : base(context, logger, utils, mapper, "Subject Task")
        {
        }
    }
}