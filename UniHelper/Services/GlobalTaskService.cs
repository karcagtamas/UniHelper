using System.Collections.Generic;
using System.Threading.Tasks;
using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;
using KarcagS.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services;

/// <summary>
/// Global Task Service
/// </summary>
public class GlobalTaskService : HttpCall<int>, IGlobalTaskService
{
    /// <summary>
    /// Init Global Task Service
    /// </summary>
    /// <param name="httpService">HTTP Service</param>
    public GlobalTaskService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/global-tasks", "Global Tasks")
    {
    }

    /// <inheritdoc />
    public async Task<List<TaskDto>> GetMyList()
    {
        var settings = new HttpSettings(Http.BuildUrl("my"));

        return await Http.Get<List<TaskDto>>(settings).ExecuteWithResult();
    }
}
