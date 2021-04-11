using System.Threading.Tasks;
using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Calendar Service
    /// </summary>
    public class CalendarService : ICalendarService
    {
        private readonly IHttpService _httpService;
        private string Url { get; set; } = ApplicationSettings.BaseApiUrl + "/calendar";
        
        /// <summary>
        /// Init Calendar Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public CalendarService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        
        /// <summary>
        /// Get Interval
        /// </summary>
        /// <param name="periodId">Destination Period Id</param>
        /// <returns>Calendar</returns>

        public async Task<CalendarDto> GetInterval(int periodId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(periodId, -1);

            var settings = new HttpSettings(Url, null, pathParams);

            return await _httpService.Get<CalendarDto>(settings);
        }

        /// <summary>
        /// Get Current Interval
        /// </summary>
        /// <returns>Current Calendar</returns>
        public async Task<CalendarDto> GetCurrentInterval()
        {
            var settings = new HttpSettings(Url);

            return await _httpService.Get<CalendarDto>(settings);
        }
    }
}