using System.Collections.Generic;
using System.Threading.Tasks;
using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Period Task Service
    /// </summary>
    public class PeriodTaskService : HttpCall<int>, IPeriodTaskService
    {
        /// <summary>
        /// Init Period Task Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public PeriodTaskService(IHttpService httpService) : base(httpService, ApplicationSettings.BaseApiUrl + "/period-tasks", "Period Task")
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