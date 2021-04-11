using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Subject Service
    /// </summary>
    public class SubjectService : CommonService<SubjectModel, SubjectDto>, ISubjectService
    {
        /// <summary>
        /// Init Subject Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public SubjectService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "subjects", httpService)
        {
        }
    }
}