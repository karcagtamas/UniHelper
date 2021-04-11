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
        /// <summary>
        /// Global Task Controller
        /// </summary>
        public GlobalTaskController(IGlobalTaskService service) : base(service)
        {
        }
    }
}