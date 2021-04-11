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
    /// Period Task Controller
    /// </summary>
    [Route("/api/period-tasks")]
    [ApiController]
    [Authorize]
    public class PeriodTaskController : MyController<PeriodTask, PeriodTaskModel, TaskDto>
    {
        /// <summary>
        /// Init Period Task Controller
        /// </summary>
        /// <param name="service">Period Task Service</param>
        public PeriodTaskController(IPeriodTaskService service) : base(service)
        {
        }
    }
}