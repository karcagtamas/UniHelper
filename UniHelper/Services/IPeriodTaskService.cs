using System.Collections.Generic;
using System.Threading.Tasks;
using KarcagS.Blazor.Common.Http;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Period Task Service
    /// </summary>
    public interface IPeriodTaskService : IHttpCall<int>
    {
        /// <summary>
        /// Get my task list
        /// </summary>
        /// <returns>Task list</returns>
        public Task<List<TaskDto>> GetMyList();
    }
}