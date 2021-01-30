using System.Threading.Tasks;
using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IHttpService _httpService;
        private string Url { get; set; } = ApplicationSettings.BaseApiUrl + "/calendar";
        
        public CalendarService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        
        public async Task<CalendarDto> GetInterval(int periodId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(periodId, -1);

            var settings = new HttpSettings(Url, null, pathParams);

            return await _httpService.Get<CalendarDto>(settings);
        }

        public async Task<CalendarDto> GetCurrentInterval()
        {
            var settings = new HttpSettings(Url);

            return await _httpService.Get<CalendarDto>(settings);
        }
    }
}