using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Global Task Service
    /// </summary>
    public class GlobalTaskService : CommonService<GlobalTaskModel, TaskDto>, IGlobalTaskService
    {
        /// <summary>
        /// Init Global Task Service
        /// </summary>
        /// <param name="httpService">HTTP Servce</param>
        public GlobalTaskService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "global-tasks", httpService)
        {
        }
    }
}