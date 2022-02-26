using System.Collections.Generic;
using System.Threading.Tasks;
using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;
using UniHelper.Shared.Enums;

namespace UniHelper.Services
{
    /// <inheritdoc />
    public class TaskService : ITaskService
    {
        private readonly IHttpService _httpService;

        private string Url { get; set; } = ApplicationSettings.BaseApiUrl + "/tasks";

        /// <summary>
        /// Init TaskService
        /// </summary>
        /// <param name="httpService"></param>
        public TaskService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<List<int>> GetParentIdList(int id, TaskType type)
        {
            var queryParams = new HttpQueryParameters();
            queryParams.Add("id", id);
            queryParams.Add("type", type);

            var settings = new HttpSettings($"{Url}/id-list").AddQueryParams(queryParams);

            return await _httpService.Get<List<int>>(settings).ExecuteWithResult();
        }
    }
}