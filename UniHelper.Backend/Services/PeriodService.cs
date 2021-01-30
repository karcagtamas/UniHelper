using System.Linq;
using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    public class PeriodService : Repository<Period>, IPeriodService
    {
        public PeriodService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper) :
            base(context, logger, utils, mapper, "Period")
        {
        }

        public int GetCurrent()
        {
            return GetList(x => x.IsCurrent).FirstOrDefault()?.Id ?? -1;
        }

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