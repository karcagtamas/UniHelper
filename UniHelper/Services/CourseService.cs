using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public class CourseService : CommonService<CourseModel, CourseDto>, ICourseService
    {
        public CourseService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "courses", httpService)
        {
        }
    }
}