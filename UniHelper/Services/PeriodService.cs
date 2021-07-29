using System.Collections.Generic;
using System.Threading.Tasks;
using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Pages;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Period Service
    /// </summary>
    public class PeriodService : CommonService<PeriodModel, PeriodDto>, IPeriodService
    {
        /// <summary>
        /// Init Period Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public PeriodService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "periods", httpService)
        {
        }

        /// <summary>
        /// Get current Period
        /// </summary>
        /// <returns>Async Id</returns>
        public async Task<int> GetCurrent()
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("current", -1);
            
            var settings = new HttpSettings(Url + "/" + this.Entity, null, pathParams);

            return await HttpService.GetInt(settings) ?? -1;
        }

        /// <summary>
        /// Set current Period
        /// </summary>
        /// <param name="id">New Period</param>
        /// <returns>Async result</returns>
        public async Task<bool> SetCurrent(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("current", -1);
            
            var settings = new HttpSettings(Url + "/" + this.Entity, null, pathParams, "Set current period");

            var body = new HttpBody<int>(id);

            return await HttpService.Update(settings, body);
        }

        /// <summary>
        /// Get user's period list
        /// </summary>
        /// <returns>List of periods</returns>
        public async Task<List<PeriodDto>> GetUserPeriodList()
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("my", -1);

            var settings = new HttpSettings(Url + "/" + this.Entity, null, pathParams);

            return await HttpService.Get<List<PeriodDto>>(settings);
        }
    }
}