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
        private readonly IPeriodService _service;

        public PeriodController(IPeriodService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("current")]
        public int GetCurrent()
        {
            return _service.GetCurrent();
        }

        [HttpPut("current")]
        public void SetCurrent([FromBody] int id)
        {
            _service.SetCurrent(id);
        }
    }
}