using System.Collections.Generic;
using System.Threading.Tasks;
using KarcagS.Blazor.Common.Http;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Period Service
    /// </summary>
    public interface IPeriodService : IHttpCall<int>
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

        /// <summary>
        /// Get user's period list
        /// </summary>
        /// <returns>List of periods</returns>
        Task<List<PeriodDto>> GetUserPeriodList();
    }
}