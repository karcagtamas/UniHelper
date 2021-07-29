using System.Collections.Generic;
using System.Threading.Tasks;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Subject Task Service
    /// </summary>
    public interface ISubjectTaskService : ICommonService<SubjectTaskModel, TaskDto>
    {
        /// <summary>
        /// Get my task list
        /// </summary>
        /// <returns>Task list</returns>
        public Task<List<TaskDto>> GetMyList();
    }
}