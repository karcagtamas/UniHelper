using System.Collections.Generic;
using System.Threading.Tasks;
using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Period Service
    /// </summary>
    public class PeriodService : HttpCall<int>, IPeriodService
    {
        /// <summary>
        /// Init Period Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public PeriodService(IHttpService httpService) : base(httpService, ApplicationSettings.BaseApiUrl + "/periods", "Period")
        {
        }

        /// <summary>
        /// Get current Period
        /// </summary>
        /// <returns>Async Id</returns>
        public async Task<int> GetCurrent()
        {
            var settings = new HttpSettings(Http.BuildUrl(Url, "current"));

            return await Http.GetInt(settings).ExecuteWithResult();
        }

        /// <summary>
        /// Set current Period
        /// </summary>
        /// <param name="id">New Period</param>
        /// <returns>Async result</returns>
        public async Task<bool> SetCurrent(int id)
        {
            var settings = new HttpSettings(Http.BuildUrl(Url, "current")).AddToaster("Set current period");

            var body = new HttpBody<int>(id);

            return await Http.Put(settings, body).Execute();
        }

        /// <summary>
        /// Get user's period list
        /// </summary>
        /// <returns>List of periods</returns>
        public async Task<List<PeriodDto>> GetUserPeriodList()
        {
            var settings = new HttpSettings(Http.BuildUrl(Url, "my"));

            return await Http.Get<List<PeriodDto>>(settings).ExecuteWithResult();
        }
    }
}