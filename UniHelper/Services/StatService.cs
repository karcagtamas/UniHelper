using System.Threading.Tasks;
using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Stat Service
    /// </summary>
    public class StatService : IStatService
    {
        private readonly IHttpService _httpService;
        private string Url { get; set; } = ApplicationSettings.BaseApiUrl + "/stat";
        
        /// <summary>
        /// Init Stat Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public StatService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        
        /// <inheritdoc />
        public async Task<StatisticDto> GetHomeStat()
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("home", -1);

            var settings = new HttpSettings(Url, null, pathParams);

            return await _httpService.Get<StatisticDto>(settings);
        }
    }
}