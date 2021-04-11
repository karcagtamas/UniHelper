using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Subject Note Service
    /// </summary>
    public class SubjectNoteService : CommonService<SubjectNoteModel, NoteDto>, ISubjectNoteService
    {
        /// <summary>
        /// Init Subject Note Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>s
        public SubjectNoteService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "subject-notes", httpService)
        {
        }
    }
}