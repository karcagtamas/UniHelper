using System.Collections.Generic;
using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    /// <summary>
    /// Global Task Controller
    /// </summary>
    [Route("/api/global-tasks")]
    [ApiController]
    [Authorize]
    public class GlobalTaskController : MyController<GlobalTask, GlobalTaskModel, TaskDto>
    {
        private readonly IGlobalTaskService _service;

        /// <summary>
        /// Global Task Controller
        /// </summary>
        public GlobalTaskController(IGlobalTaskService service) : base(service)
        {
            _service = service;
        }
        
        /// <summary>
        /// Get My List
        /// </summary>
        /// <returns>Task list</returns>
        [HttpGet("my")]
        public List<TaskDto> GetMyList()
        {
            return _service.GetMyList();
        }
    }
}