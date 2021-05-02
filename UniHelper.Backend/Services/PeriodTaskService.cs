using System.Collections.Generic;
using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using Microsoft.EntityFrameworkCore;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc cref="UniHelper.Backend.Services.IPeriodTaskService" />
    public class PeriodTaskService : Repository<PeriodTask>, IPeriodTaskService
    {
        private readonly ICommonService _commonService;

        /// <summary>
        /// Period Task Service
        /// </summary>
        /// <param name="context">Database Context</param>
        /// <param name="logger">Logger</param>
        /// <param name="utils">Utils Service</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="commonService">Common Service</param>
        public PeriodTaskService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper, ICommonService commonService) : base(context, logger, utils, mapper, "Period Task")
        {
            _commonService = commonService;
        }

        /// <inheritdoc />
        public List<TaskDto> GetMyList()
        {
            var user = _commonService.GetLoggedUserId();
            return user == -1 ? new List<TaskDto>() : GetList<TaskDto>(x => x.Period.UserId == user);
        }
    }
}