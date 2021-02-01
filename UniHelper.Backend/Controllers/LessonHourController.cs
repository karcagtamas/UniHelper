using Karcags.Common.Tools;
using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    [ApiController]
    [Route("/api/lesson-hours")]
    public class LessonHourController : MyController<LessonHour, LessonHourModel, LessonHourDto>
    {
        private readonly ILessonHourService _service;

        public LessonHourController(ILessonHourService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("interval")]
        public LessonHourIntervalDto GetHourInterval([FromQuery] int from, [FromQuery] int to)
        {
            return _service.GetHourInterval(from, to);
        }
    }
}