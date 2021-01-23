using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public class PeriodNoteService : CommonService<PeriodNoteModel, NoteDto>, IPeriodNoteService
    {
        public PeriodNoteService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "period-notes", httpService)
        {
        }
    }
}