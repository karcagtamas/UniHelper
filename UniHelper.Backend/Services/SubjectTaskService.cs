using System.Collections.Generic;
using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc cref="UniHelper.Backend.Services.ISubjectTaskService" />
    public class SubjectTaskService : Repository<SubjectTask>, ISubjectTaskService
    {
        private readonly ICommonService _commonService;

        /// <summary>
        /// Init Subject Task Service
        /// </summary>
        /// <param name="context">Database Context</param>
        /// <param name="logger">Logger</param>
        /// <param name="utils">Utils Service</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="commonService">Common Service</param>
        public SubjectTaskService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper, ICommonService commonService) : base(context, logger, utils, mapper, "Subject Task")
        {
            _commonService = commonService;
        }
        
        /// <inheritdoc />
        public List<TaskDto> GetMyList()
        {
            var user = _commonService.GetLoggedUserId();
            return user == -1 ? new List<TaskDto>() : GetList<TaskDto>(x => x.Subject.Period.UserId == user);
        }
    }
}