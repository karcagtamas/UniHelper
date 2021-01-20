using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using Microsoft.EntityFrameworkCore;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    public class SubjectService : Repository<Subject>, ISubjectService
    {
        public SubjectService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper,
            string entity) : base(context, logger, utils, mapper, entity)
        {
        }
    }
}