using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Subject Service
    /// </summary>
    public class SubjectService : HttpCall<int>, ISubjectService
    {
        /// <summary>
        /// Init Subject Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public SubjectService(IHttpService httpService) : base(httpService, ApplicationSettings.BaseApiUrl + "/subjects", "Subject")
        {
        }
    }
}