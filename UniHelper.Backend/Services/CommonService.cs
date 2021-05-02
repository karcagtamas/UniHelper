using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace UniHelper.Backend.Services
{
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
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst("id")?.Value ?? "";

            if (!string.IsNullOrEmpty(userId))
            {
                return int.Parse(userId);
            }

            return -1;
        }
    }
}