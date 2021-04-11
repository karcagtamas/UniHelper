using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Global Note Service
    /// </summary>
    public class GlobalNoteService : CommonService<GlobalNoteModel, NoteDto>, IGlobalNoteService
    {
        /// <summary>
        /// Init global Note Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public GlobalNoteService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "global-notes", httpService)
        {
        }
    }
}