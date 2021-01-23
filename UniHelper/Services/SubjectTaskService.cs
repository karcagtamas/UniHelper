using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public class SubjectTaskService : CommonService<SubjectTaskModel, TaskDto>, ISubjectTaskService
    {
        public SubjectTaskService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "subject-tasks", httpService)
        {
        }
    }
}