using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Services;
using UniHelper.Shared.Enums;

namespace UniHelper.Backend.Controllers
{
    /// <summary>
    /// Task Controller
    /// </summary>
    [Route("/api/tasks")]
    [ApiController]
    [Authorize]
    public class TaskController
    {
        private readonly ITaskService _taskService;
        
        /// <summary>
        /// Task Controller Init
        /// </summary>
        /// <param name="taskService">Task Service</param>
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        /// <summary>
        /// Get parent list id of a task
        /// </summary>
        /// <param name="id">Task id</param>
        /// <param name="type">Task type</param>
        /// <returns>Parent id list</returns>
        [HttpGet("id-list")]
        public List<int> GetParentIdList([FromQuery] int id, [FromQuery] TaskType type)
        {
            return _taskService.GetParentIdList(id, type);
        }
    }
}