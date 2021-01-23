using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

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