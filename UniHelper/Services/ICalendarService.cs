using System.Threading.Tasks;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Calendar Service
    /// </summary>
    public interface ICalendarService
    {
        /// <summary>
        /// Get Interval
        /// </summary>
        /// <param name="periodId">Destination Period Id</param>
        /// <returns>Calendar</returns>
        Task<CalendarDto> GetInterval(int periodId);

        /// <summary>
        /// Get Current Interval
        /// </summary>
        /// <returns>Current Calendar</returns>
        Task<CalendarDto> GetCurrentInterval();
    }
}