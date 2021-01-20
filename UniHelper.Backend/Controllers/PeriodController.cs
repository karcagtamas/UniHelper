using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Models;
using UniHelper.Backend.Services;

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