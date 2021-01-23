using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public class SubjectNoteService : CommonService<SubjectNoteModel, NoteDto>, ISubjectNoteService
    {
        public SubjectNoteService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "subject-notes", httpService)
        {
        }
    }
}