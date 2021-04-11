using System;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <summary>
    /// Calender Service
    /// </summary>
    public interface ICalendarService
    {
        /// <summary>
        /// Get Current Calender interval
        /// </summary>
        /// <returns>Calendar</returns>
        CalendarDto GetCurrentInterval();

        /// <summary>
        /// Get interval by Id
        /// </summary>
        /// <param name="periodId">Period Id</param>
        /// <returns>Calendar</returns>
        CalendarDto GetInterval(int periodId);
    }
}