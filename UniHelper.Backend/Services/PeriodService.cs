using System.Linq;
using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc cref="UniHelper.Backend.Services.IPeriodService" />
    public class PeriodService : Repository<Period>, IPeriodService
    {
        /// <summary>
        /// Init Period Service
        /// </summary>
        /// <param name="context">Database Context</param>
        /// <param name="logger">Logger</param>
        /// <param name="utils">Utils Service</param>
        /// <param name="mapper">Mapper</param>
        public PeriodService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper) :
            base(context, logger, utils, mapper, "Period")
        {
        }

        /// <inheritdoc />
        public int GetCurrent()
        {
            return GetList(x => x.IsCurrent).FirstOrDefault()?.Id ?? -1;
        }

        /// <inheritdoc />
        public void SetCurrent(int id)
        {
            if (GetCurrent() == id)
            {
                return;
            }

            var period = Get(id);

            if (period == null)
            {
                return;
            }

            period.IsCurrent = true;
            Update(period);
            Complete();

            var others = GetList(x => x.Id != id);

            others.ForEach(x => x.IsCurrent = false);
            UpdateRange(others);
            Complete();
        }
    }
}