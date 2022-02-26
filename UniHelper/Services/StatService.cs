using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;
using System.Threading.Tasks;
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
            var settings = new HttpSettings(_httpService.BuildUrl(Url, "home"));

            return await _httpService.Get<StatisticDto>(settings).ExecuteWithResult();
        }
    }
}