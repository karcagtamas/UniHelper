using KarcagS.Blazor.Common.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Subject Task Service
    /// </summary>
    public interface ISubjectTaskService : IHttpCall<int>
    {
        /// <summary>
        /// Get my task list
        /// </summary>
        /// <returns>Task list</returns>
        public Task<List<TaskDto>> GetMyList();
    }
}