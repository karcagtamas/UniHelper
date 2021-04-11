using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc cref="UniHelper.Backend.Services.IGlobalNoteService" />
    public class GlobalNoteService : Repository<GlobalNote>, IGlobalNoteService
    {
        /// <summary>
        /// Init Global Note Service
        /// </summary>
        /// <param name="context">Database Context</param>
        /// <param name="logger">Logger</param>
        /// <param name="utils">Utils service</param>
        /// <param name="mapper">Mapper</param>
        public GlobalNoteService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper) :
            base(context, logger, utils, mapper, "Global Note")
        {
        }
    }
}