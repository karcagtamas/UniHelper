using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public class GlobalTaskService : CommonService<GlobalTaskModel, TaskDto>, IGlobalTaskService
    {
        public GlobalTaskService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "global-tasks", httpService)
        {
        }
    }
}