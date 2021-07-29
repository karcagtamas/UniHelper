using System.Collections.Generic;
using Karcags.Common.Tools;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <summary>
    /// Period Service
    /// </summary>
    public interface IPeriodService : IRepository<Period>
    {
        /// <summary>
        /// Get current Period
        /// </summary>
        /// <returns>Period</returns>
        int GetCurrent();

        /// <summary>
        /// Set current Period
        /// </summary>
        /// <param name="id">New Period's Id</param>
        void SetCurrent(int id);

        /// <summary>
        /// Get user's period list
        /// </summary>
        /// <returns>List of periods</returns>
        List<PeriodDto> GetUserPeriodList();
    }
}