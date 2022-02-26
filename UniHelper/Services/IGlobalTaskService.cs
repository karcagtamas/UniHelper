using System.Collections.Generic;
using System.Threading.Tasks;
using KarcagS.Blazor.Common.Http;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Global Task Service
    /// </summary>
    public interface IGlobalTaskService : IHttpCall<int>
    {
        /// <summary>
        /// Get my task list
        /// </summary>
        /// <returns>Task list</returns>
        public Task<List<TaskDto>> GetMyList();
    }
}