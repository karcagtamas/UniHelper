using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <summary>
    /// Statistic Service
    /// </summary>
    public interface IStatService
    {
        /// <summary>
        /// Get Home statistic
        /// </summary>
        /// <returns>Statistic object</returns>
        StatisticDto GetHomeStat();
    }
}