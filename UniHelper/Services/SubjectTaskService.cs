using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Subject Task Service
    /// </summary>
    public class SubjectTaskService : CommonService<SubjectTaskModel, TaskDto>, ISubjectTaskService
    {
        /// <summary>
        /// Init Subject Task Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public SubjectTaskService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "subject-tasks", httpService)
        {
        }
    }
}