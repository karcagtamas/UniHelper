using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    [Route("/api/global-tasks")]
    [ApiController]
    public class GlobalTaskController : MyController<GlobalTask, GlobalTaskModel, TaskDto>
    {
        public GlobalTaskController(IGlobalTaskService service) : base(service)
        {
        }
    }
}