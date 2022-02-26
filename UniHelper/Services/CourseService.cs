using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Course Service
    /// </summary>
    public class CourseService : HttpCall<int>, ICourseService
    {
        /// <summary>
        /// Init Course Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public CourseService(IHttpService httpService) : base(httpService, ApplicationSettings.BaseApiUrl, "Course")
        {
        }
    }
}