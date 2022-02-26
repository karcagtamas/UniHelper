using System.Collections.Generic;
using KarcagS.Common.Tools.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services.Interfaces;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    /// <summary>
    /// Period Task Controller
    /// </summary>
    [Route("/api/period-tasks")]
    [ApiController]
    [Authorize]
    public class PeriodTaskController : MapperController<PeriodTask, int, PeriodTaskModel, TaskDto>
    {
        private readonly IPeriodTaskService _service;

        /// <summary>
        /// Init Period Task Controller
        /// </summary>
        /// <param name="service">Period Task Service</param>
        public PeriodTaskController(IPeriodTaskService service) : base(service)
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