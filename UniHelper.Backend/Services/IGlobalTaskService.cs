using System.Collections.Generic;
using Karcags.Common.Tools;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <summary>
    /// Global Task Service
    /// </summary>
    public interface IGlobalTaskService : IRepository<GlobalTask>
    {
        /// <summary>
        /// Get My List
        /// </summary>
        /// <returns>Task list</returns>
        List<TaskDto> GetMyList();
    }
}