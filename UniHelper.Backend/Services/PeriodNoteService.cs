using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    public class PeriodNoteService : Repository<PeriodNote>, IPeriodNoteService
    {
        public PeriodNoteService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper, string entity) : base(context, logger, utils, mapper, entity)
        {
        }
    }
}