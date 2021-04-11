using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Period Note Service
    /// </summary>
    public class PeriodNoteService : CommonService<PeriodNoteModel, NoteDto>, IPeriodNoteService
    {
        /// <summary>
        /// Init Period Note Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public PeriodNoteService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "period-notes", httpService)
        {
        }
    }
}