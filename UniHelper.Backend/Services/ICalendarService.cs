using System;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    public interface ICalendarService
    {
        CalendarDto GetCurrentInterval();
        CalendarDto GetInterval(int periodId);
    }
}