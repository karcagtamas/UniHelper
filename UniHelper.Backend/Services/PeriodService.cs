using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using Microsoft.AspNetCore.Http;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc cref="UniHelper.Backend.Services.IPeriodService" />
    public class PeriodService : Repository<Period>, IPeriodService
    {
        private readonly ICommonService _commonService;

        /// <summary>
        /// Init Period Service
        /// </summary>
        /// <param name="context">Database Context</param>
        /// <param name="logger">Logger</param>
        /// <param name="utils">Utils Service</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="commonService">Common Service</param>
        public PeriodService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper, ICommonService commonService) :
            base(context, logger, utils, mapper, "Period")
        {
            _commonService = commonService;
        }

        /// <inheritdoc />
        public int GetCurrent()
        {
            var user = _commonService.GetLoggedUserId();
            if (user == -1)
            {
                return -1;
            }
            
            return GetList(x => x.IsCurrent && x.UserId == user).FirstOrDefault()?.Id ?? -1;
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

            var others = GetUserPeriods().Where(x => x.Id != id).ToList();

            others.ForEach(x => x.IsCurrent = false);
            UpdateRange(others);
            Complete();
        }

        /// <inheritdoc />
        public List<PeriodDto> GetUserPeriodList()
        {
            var user = _commonService.GetLoggedUserId();
            return user == -1 ? new List<PeriodDto>() : GetList<PeriodDto>(x => x.UserId == user);
        }
        
        private List<Period> GetUserPeriods()
        {
            var user = _commonService.GetLoggedUserId();
            return user == -1 ? new List<Period>() : GetList(x => x.UserId == user);
        }
    }
}