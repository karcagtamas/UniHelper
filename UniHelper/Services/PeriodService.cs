using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public class PeriodService : CommonService<PeriodModel, PeriodDto>, IPeriodService
    {
        public PeriodService(IHttpService httpService) : base(ApplicationSettings.BaseApiUrl, "periods", httpService)
        {
        }
    }
}