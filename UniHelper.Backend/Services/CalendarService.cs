using System;
using System.Collections.Generic;
using System.Linq;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IPeriodService _periodService;

        public CalendarService(IPeriodService periodService)
        {
            _periodService = periodService;
        }

        public CalendarDto GetInterval(int periodId)
        {
            var current = _periodService.Get(periodId);

            if (current == null)
            {
                return null;
            }

            var calendar = new CalendarDto
            {
                PeriodId = current.Id,
                PeriodName = current.Name,
                Days = new List<DayDto>()
            };
            var dayList = new List<DayDto>();

            Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList().ForEach(x =>
            {
                dayList.Add(new DayDto {Tiles = new List<TileDto>(), DayOfWeek = x});
            });
            
            current.Subjects.ToList().ForEach(sub =>
            {
                sub.Courses.ToList().ForEach(cour =>
                {
                    var dayId = dayList.FindIndex(x => (int) x.DayOfWeek == cour.Day);

                    if (dayId == -1)
                    {
                        throw new ArgumentException("Invalid day");
                    }
                    
                    dayList[dayId].Tiles.Add(new TileDto
                    {
                        CourseId = cour.Id,
                        SubjectId = sub.Id,
                        Place = cour.Place,
                        SubjectShortName = sub.ShortName,
                        SubjectLongName = sub.LongName,
                        Number = cour.Number,
                        Length = cour.Length
                    });
                });
            });

            calendar.Days = dayList;
            return calendar;
        }

        public CalendarDto GetCurrentInterval()
        {
            var current = _periodService.GetCurrent();

            return current == -1 ? null : GetInterval(current);
        }
    }
}