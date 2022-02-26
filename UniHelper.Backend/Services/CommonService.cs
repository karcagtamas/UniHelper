using Microsoft.AspNetCore.Http;
using UniHelper.Backend.Services.Interfaces;

namespace UniHelper.Backend.Services;

/// <inheritdoc />
public class CommonService : ICommonService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpContextAccessor">Http Context Accessor</param>
    public CommonService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc />
    public int GetLoggedUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst("userid")?.Value ?? "";

        if (!string.IsNullOrEmpty(userId))
        {
            return int.Parse(userId);
        }

        return -1;
    }
}
