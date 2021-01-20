using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using Microsoft.EntityFrameworkCore;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    public class PeriodTaskService : Repository<PeriodTask>, IPeriodTaskService
    {
        public PeriodTaskService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper,
            string entity) : base(context, logger, utils, mapper, entity)
        {
        }
    }
}