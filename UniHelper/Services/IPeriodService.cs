using System.Threading.Tasks;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Period Service
    /// </summary>
    public interface IPeriodService : ICommonService<PeriodModel, PeriodDto>
    {
        /// <summary>
        /// Get current Period
        /// </summary>
        /// <returns>Async Id</returns>
        Task<int> GetCurrent();

        /// <summary>
        /// Set current Period
        /// </summary>
        /// <param name="id">New Period</param>
        /// <returns>Async result</returns>
        Task<bool> SetCurrent(int id);
    }
}