using System.Collections.Generic;
using System.Threading.Tasks;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Global Task Service
    /// </summary>
    public interface IGlobalTaskService : ICommonService<GlobalTaskModel, TaskDto>
    {
        /// <summary>
        /// Get my task list
        /// </summary>
        /// <returns>Task list</returns>
        public Task<List<TaskDto>> GetMyList();
    }
}