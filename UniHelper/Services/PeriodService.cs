using System.Threading.Tasks;
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

        public async Task<int> GetCurrent()
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("current", -1);
            
            var settings = new HttpSettings(Url + "/" + this.Entity, null, pathParams);

            return await HttpService.GetInt(settings) ?? -1;
        }

        public async Task<bool> SetCurrent(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("current", -1);
            
            var settings = new HttpSettings(Url + "/" + this.Entity, null, pathParams);

            var body = new HttpBody<int>(id);

            return await HttpService.Update(settings, body);
        }
    }
}