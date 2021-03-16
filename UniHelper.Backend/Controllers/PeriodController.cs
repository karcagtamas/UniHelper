using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    /// <summary>
    /// Period Controller
    /// </summary>
    [Route("api/periods")]
    [ApiController]
    public class PeriodController : MyController<Period, PeriodModel, PeriodDto>
    {
        private readonly IPeriodService _service;

        /// <summary>
        /// Period Controller
        /// </summary>
        public PeriodController(IPeriodService service) : base(service)
        {
            _service = service;
        }

        /// <summary>
        /// Get current Period
        /// </summary>
        /// <returns></returns>
        [HttpGet("current")]
        public int GetCurrent()
        {
            return _service.GetCurrent();
        }

        /// <summary>
        /// Set current Period by Id
        /// </summary>
        /// <param name="id">Period Id</param>
        [HttpPut("current")]
        public void SetCurrent([FromBody] int id)
        {
            _service.SetCurrent(id);
        }
    }
}