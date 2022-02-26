using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Services.Interfaces;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Controllers;

/// <summary>
/// Calendar Controller
/// </summary>
[Route("/api/calendar")]
[ApiController]
[Authorize]
public class CalendarController
{
    private readonly ICalendarService _calendarService;

    /// <summary>
    /// Calendar Controller
    /// </summary>
    /// <param name="calendarService">Calendar Service</param>
    public CalendarController(ICalendarService calendarService)
    {
        _calendarService = calendarService;
    }

    /// <summary>
    /// Get time interval
    /// </summary>
    /// <param name="id">Period Id</param>
    /// <returns>Calendar Interval</returns>
    [HttpGet("{id}")]
    public CalendarDto GetInterval(int id)
    {
        return _calendarService.GetInterval(id);
    }

    /// <summary>
    /// Get current time interval
    /// </summary>
    /// <returns>Current Calendar Interval</returns>
    [HttpGet]
    public CalendarDto GetCurrentInterval()
    {
        return _calendarService.GetCurrentInterval();
    }
}
