using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public class GlobalNoteService : CommonService<GlobalNoteModel, NoteDto>, IGlobalNoteService
    {
        public GlobalNoteService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "global-notes", httpService)
        {
        }
    }
}