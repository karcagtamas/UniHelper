using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public class PeriodTaskService : CommonService<PeriodTaskModel, TaskDto>, IPeriodTaskService
    {
        public PeriodTaskService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "period-tasks", httpService)
        {
        }
    }
}