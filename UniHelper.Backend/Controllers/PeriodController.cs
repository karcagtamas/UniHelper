using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    [Route("api/periods")]
    [ApiController]
    public class PeriodController : MyController<Period, PeriodModel, PeriodDto>
    {
        public PeriodController(IPeriodService service) : base(service)
        {
        }
    }
}