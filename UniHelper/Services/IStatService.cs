using System.Threading.Tasks;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Stat Service
    /// </summary>
    public interface IStatService
    {
        /// <summary>
        /// Get Home statistic
        /// </summary>
        /// <returns>Statistic object</returns>
        Task<StatisticDto> GetHomeStat();
    }
}