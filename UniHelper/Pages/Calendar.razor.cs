using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UniHelper.Models;
using UniHelper.Services;
using UniHelper.Shared.DTOs;

namespace UniHelper.Pages
{
    public partial class Calendar
    {
        [Inject] private ICalendarService CalendarService { get; set; }

        private CalendarDto CalendarData { get; set; }

        private List<CalendarRow> Rows { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            CalendarData = await CalendarService.GetCurrentInterval();
            ResetRows();
            InitRows();
        }

        private void ResetRows()
        {
            Rows = new List<CalendarRow>();

            for (int i = 0; i <= 10; i++)
            {
                var row = new CalendarRow
                {
                    Number = i,
                    Cells = new List<CalendarCell>()
                };

                foreach (var day in Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList())
                {
                    row.Cells.Add(new CalendarCell
                    {
                        Day = day,
                        Tiles = new List<TileDto>(),
                        DoTile = true,
                        HasRowSpan = false,
                        RowSpanNumber = 1
                    });
                }

                Rows.Add(row);
            }
        }

        private void InitRows()
        {
            if (Rows == null)
            {
                return;
            }

            CalendarData.Days.ForEach(day =>
            {
                day.Tiles.ForEach(tile =>
                {
                    int number = tile.Number;
                    int count = tile.Length;

                    while (count > 0)
                    {
                        var row = Rows.FirstOrDefault(x => x.Number == number);

                        if (row == null)
                        {
                            throw new ArgumentException("Missing row");
                        }

                        var cell = row.Cells.FirstOrDefault(x => x.Day == day.DayOfWeek);

                        if (cell == null)
                        {
                            throw new ArgumentException("Missing cell");
                        }

                        if (number == tile.Number)
                        {
                            cell.Tiles.Add(tile);
                            if (tile.Length > 1)
                            {
                                cell.HasRowSpan = true;
                                cell.RowSpanNumber = tile.Length;
                            }
                        }
                        else
                        {
                            cell.DoTile = false;
                        }
                        
                        number++;
                        count--;
                    }
                });
            });
        }
    }
}