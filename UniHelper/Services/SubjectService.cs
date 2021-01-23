using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public class SubjectService : CommonService<SubjectModel, SubjectDto>, ISubjectService
    {
        public SubjectService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "subjects", httpService)
        {
        }
    }
}