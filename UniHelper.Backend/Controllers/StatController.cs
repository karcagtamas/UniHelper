using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Services.Interfaces;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Controllers
{
    /// <summary>
    /// Stat Controller
    /// </summary>
    [Route("api/stat")]
    [ApiController]
    [Authorize]
    public class StatController
    {
        private readonly IStatService _statService;

        /// <summary>
        /// Init Stat Controller
        /// </summary>
        /// <param name="statService">Stat Service</param>
        public StatController(IStatService statService)
        {
            _statService = statService;
        }
        
        /// <summary>
        /// Get Home stat
        /// </summary>
        /// <returns>Statistic object</returns>
        [HttpGet("home")]
        public StatisticDto GetHomeStat()
        {
            return _statService.GetHomeStat();
        }
    }
}