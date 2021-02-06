using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UniHelper.Models;
using UniHelper.Services;
using UniHelper.Shared.DTOs;

namespace UniHelper.Pages
{
    public partial class Calendar
    {
        [Inject] private ICalendarService CalendarService { get; set; }
        
        [Inject]
        private ILessonHourService LessonHourService { get; set; }

        private CalendarDto CalendarData { get; set; }
        private List<LessonHourDto> LessonHours { get; set; } = new();
        
        private List<CalendarHeaderData> HeaderRow { get; set; }

        private List<CalendarRow> Rows { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            CalendarData = await CalendarService.GetCurrentInterval();
            LessonHours = await LessonHourService.GetList();
            ResetHeader();
            ResetRows();
            InitRows();
        }

        private void ResetHeader()
        {
            HeaderRow = new List<CalendarHeaderData>();
            
            CalendarData.Days.ForEach(x =>
            {
                HeaderRow.Add(new CalendarHeaderData
                {
                    ColSpanNumber = 1,
                    HasColSpan = false,
                    Day = x.DayOfWeek,
                    DoTile = true
                });
            });
        }

        private void ResetRows()
        {
            Rows = new List<CalendarRow>();
            
            LessonHours.OrderBy(x => x.Number).ToList().ForEach(hour =>
            {
                var row = new CalendarRow
                {
                    LessonHour = hour,
                    Cells = new List<CalendarCell>()
                };

                foreach (var day in Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList())
                {
                    row.Cells.Add(new CalendarCell
                    {
                        Day = day,
                        Tile = null,
                        DoTile = true,
                        HasRowSpan = false,
                        RowSpanNumber = 1
                    });
                }

                Rows.Add(row);
            });
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
                    bool success = false;
                    int cellNumber = 0;

                    while (!success)
                    {
                        List<CalendarCell> cells = new List<CalendarCell>();
                        int number = tile.Number;
                        int count = tile.Length;

                        while (count > 0)
                        {
                            var row = Rows.FirstOrDefault(x => x.LessonHour.Number == number);

                            if (row == null)
                            {
                                throw new ArgumentException("Missing row");
                            }

                            var cellsWithGivenDay = row.Cells.Where(x => x.Day == day.DayOfWeek).ToList();
                            var cell = cellsWithGivenDay[cellNumber];

                            if (cell == null)
                            {
                                throw new ArgumentException("Missing cell");
                            }
                        
                            cells.Add(cell);

                            number++;
                            count--;
                        }
                        
                        var c = cells.Count(x => x.Tile != null);

                        if (c > 0)
                        {
                            var cell = cells[0];
                            // TODO: Checks
                            var index = Rows[0].Cells.FindIndex(x => x.Day == cell.Day);
                            Rows.ForEach(x =>
                            {
                                x.Cells.Insert(index + 1, new CalendarCell
                                {
                                    Day = cell.Day,
                                    Tile = null,
                                    DoTile = true,
                                    HasRowSpan = false,
                                    RowSpanNumber = 1
                                });
                            });

                            HeaderRow[index].ColSpanNumber++;
                            HeaderRow[index].HasColSpan = true;
                            
                            HeaderRow.Insert(index + 1, new CalendarHeaderData
                            {
                                Day = cell.Day,
                                ColSpanNumber = 1,
                                DoTile = false,
                                HasColSpan = false
                            });
                            cellNumber++;
                            continue;
                        }
                        
                        for (int i = 0; i < cells.Count; i++)
                        {
                            if (i == 0)
                            {
                                cells[i].Tile = tile;
                                if (tile.Length > 1)
                                {
                                    cells[i].HasRowSpan = true;
                                    cells[i].RowSpanNumber = tile.Length;
                                }
                            }
                            else
                            {
                                cells[i].DoTile = false;
                            }
                        }

                        success = true;
                    }
                });
            });
        }

        private void OnHover(MouseEventArgs eventArgs, CalendarCell cell, bool activate)
        {
            cell.IsHovered = activate;
            
            Rows.ForEach(x =>
            {
                x.Cells.ForEach(c =>
                {
                    // TODO: Subject Id
                    if (c.Tile?.SubjectShortName == cell.Tile?.SubjectShortName)
                    {
                        c.IsHovered = activate;
                    }
                });
            });
        }
    }
}