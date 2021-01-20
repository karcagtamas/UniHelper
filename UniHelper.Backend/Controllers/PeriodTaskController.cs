using Karcags.Common.Tools;
using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Models;
using UniHelper.Backend.Services;

namespace UniHelper.Backend.Controllers
{
    [Route("/api/period-tasks")]
    [ApiController]
    public class PeriodTaskController : MyController<PeriodTask, PeriodTaskModel, TaskDto>
    {
        public PeriodTaskController(IPeriodTaskService service) : base(service)
        {
        }
    }
}