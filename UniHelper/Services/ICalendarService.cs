using System.Threading.Tasks;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    public interface ICalendarService
    {
        Task<CalendarDto> GetInterval(int periodId);
        Task<CalendarDto> GetCurrentInterval();
    }
}