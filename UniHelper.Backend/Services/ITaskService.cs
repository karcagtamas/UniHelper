using System.Collections.Generic;
using UniHelper.Shared.Enums;

namespace UniHelper.Backend.Services
{
    /// <summary>
    /// Task Service
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Get parent list id of a task
        /// </summary>
        /// <param name="id">Task id</param>
        /// <param name="type">Task type</param>
        /// <returns>Parent id list</returns>
        List<int> GetParentIdList(int id, TaskType type);
    }
}