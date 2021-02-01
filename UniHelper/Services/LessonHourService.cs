using System.Threading.Tasks;
using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public class LessonHourService : CommonService<LessonHourModel, LessonHourDto>, ILessonHourService
    {
        public LessonHourService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "lesson-hours", httpService)
        {
        }

        public Task<LessonHourIntervalDto> GetHourInterval(int from, int to)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("interval", -1);
            
            var queryParams = new HttpQueryParameters();
            queryParams.Add("from", from);
            queryParams.Add("to", to);

            var settings = new HttpSettings(Url + "/" + this.Entity, queryParams, pathParams);

            return HttpService.Get<LessonHourIntervalDto>(settings);
        }
    }
}