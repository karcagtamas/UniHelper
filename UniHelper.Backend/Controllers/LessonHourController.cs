using Karcags.Common.Tools;
using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    /// <summary>
    /// Lesson Hour Controller
    /// </summary>
    [ApiController]
    [Route("/api/lesson-hours")]
    public class LessonHourController : MyController<LessonHour, LessonHourModel, LessonHourDto>
    {
        private readonly ILessonHourService _service;

        /// <summary>
        /// Lesson Hour Controller
        /// </summary>
        public LessonHourController(ILessonHourService service) : base(service)
        {
            _service = service;
        }
        
        /// <summary>
        /// Get hour interval by interval end points
        /// </summary>
        /// <param name="from">From number</param>
        /// <param name="to">To number</param>
        /// <returns>Lesson hour interval</returns>
        [HttpGet("interval")]
        public LessonHourIntervalDto GetHourInterval([FromQuery] int from, [FromQuery] int to)
        {
            return _service.GetHourInterval(from, to);
        }
    }
}