using System.Threading.Tasks;
using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Lesson hour Service
    /// </summary>
    public class LessonHourService : HttpCall<int>, ILessonHourService
    {
        /// <summary>
        /// Init Lesson hour Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public LessonHourService(IHttpService httpService) : base(httpService, ApplicationSettings.BaseApiUrl + "/lesson-hours", "Lesson Hours")
        {
        }

        /// <summary>
        /// Get Hour interval by endpoints
        /// </summary>
        /// <param name="from">From number</param>
        /// <param name="to">To number</param>
        /// <returns>Create Hour interval</returns>
        public Task<LessonHourIntervalDto> GetHourInterval(int from, int to)
        {
            var queryParams = new HttpQueryParameters();
            queryParams.Add("from", from);
            queryParams.Add("to", to);

            var settings = new HttpSettings(Http.BuildUrl(Url, "interval")).AddQueryParams(queryParams);

            return Http.Get<LessonHourIntervalDto>(settings).ExecuteWithResult();
        }
    }
}