using System.Collections.Generic;
using System.Threading.Tasks;
using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Subject Task Service
    /// </summary>
    public class SubjectTaskService : HttpCall<int>, ISubjectTaskService
    {
        /// <summary>
        /// Init Subject Task Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public SubjectTaskService(IHttpService httpService) : base(httpService, ApplicationSettings.BaseApiUrl + "/subject-tasks", "Subject Task")
        {
            
        }

        /// <inheritdoc />
        public async Task<List<TaskDto>> GetMyList()
        {
            var settings = new HttpSettings(Http.BuildUrl(Url, "my"));

            return await Http.Get<List<TaskDto>>(settings).ExecuteWithResult();
        }
    }
}