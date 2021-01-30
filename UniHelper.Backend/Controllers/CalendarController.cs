using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Controllers
{
    [Route("/api/calendar")]
    [ApiController]
    public class CalendarController
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpGet("{id}")]
        public CalendarDto GetInterval(int id)
        {
            return _calendarService.GetInterval(id);
        }

        [HttpGet]
        public CalendarDto GetCurrentInterval()
        {
            return _calendarService.GetCurrentInterval();
        }
    }
}