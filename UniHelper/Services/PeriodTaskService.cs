using System.Collections.Generic;
using System.Threading.Tasks;
using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Period Task Service
    /// </summary>
    public class PeriodTaskService : CommonService<PeriodTaskModel, TaskDto>, IPeriodTaskService
    {
        /// <summary>
        /// Init Period Task Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public PeriodTaskService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "period-tasks", httpService)
        {
        }
        
        /// <inheritdoc />
        public async Task<List<TaskDto>> GetMyList()
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("my", -1);

            var settings = new HttpSettings(Url + "/" + this.Entity, null, pathParams);

            return await HttpService.Get<List<TaskDto>>(settings);
        }
    }
}