using Karcags.Common.Tools;
using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Models;
using UniHelper.Backend.Services;

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