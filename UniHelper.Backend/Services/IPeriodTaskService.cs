using System.Collections.Generic;
using Karcags.Common.Tools;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <summary>
    /// Period Task Service
    /// </summary>
    public interface IPeriodTaskService : IRepository<PeriodTask>
    {
        /// <summary>
        /// Get My List
        /// </summary>
        /// <returns>Task list</returns>
        List<TaskDto> GetMyList();
    }
}