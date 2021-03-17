using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Course Service
    /// </summary>
    public class CourseService : CommonService<CourseModel, CourseDto>, ICourseService
    {
        /// <summary>
        /// Init Course Service
        /// </summary>
        /// <param name="httpService">HTTP Servce</param>
        public CourseService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "courses", httpService)
        {
        }
    }
}