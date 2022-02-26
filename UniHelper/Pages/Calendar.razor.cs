using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using UniHelper.Models;
using UniHelper.Services;
using UniHelper.Shared.Dialogs;
using UniHelper.Shared.DTOs;

namespace UniHelper.Pages
{
    /// <summary>
    /// Calendar Page
    /// </summary>
    public partial class Calendar
    {
        [Inject] private ICalendarService CalendarService { get; set; }

        [Inject] private ILessonHourService LessonHourService { get; set; }

        [Inject] private IDialogService DialogService { get; set; }

        private CalendarDto CalendarData { get; set; }
        private List<LessonHourDto> LessonHours { get; set; } = new();

        private List<CalendarHeaderData> HeaderRow { get; set; }

        private List<CalendarRow> Rows { get; set; }

        private bool RemoveEmptyCols { get; set; }

        private bool RemoveWeekendCols { get; set; } = true;

        private bool RemoveEmptyFirstAndLastRows { get; set; } = true;

        /// <summary>
        /// Init Calendar
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            CalendarData = await CalendarService.GetCurrentInterval();
            LessonHours = await LessonHourService.GetAll<LessonHourDto>();
            BuildTable();
        }

        private void BuildTable()
        {
            if (CalendarData != null)
            {
                ResetHeader();
                ResetRows();
                InitRows();
                DoFilter();
                StateHasChanged();
            }
            else
            {
                HeaderRow = new List<CalendarHeaderData>();
                Rows = new List<CalendarRow>();
            }
        }

        private void DoFilter()
        {
            FilterWeekendCols();
            FilterEmptyCols();
            FilterEmptyFirstAndLastRows();
        }

        private void FilterEmptyCols()
        {
            if (!RemoveEmptyCols) return;
            var counts = new int[HeaderRow.Count];
            Rows.ForEach(x =>
            {
                for (var i = 0; i < x.Cells.Count; i++)
                {
                    if (x.Cells[i].HasValue)
                    {
                        counts[i]++;
                    }
                }
            });

            for (var i = counts.Length - 1; i >= 0; i--)
            {
                if (counts[i] != 0) continue;
                HeaderRow.RemoveAt(i);
                foreach (var row in Rows)
                {
                    row.Cells.RemoveAt(i);
                }
            }
        }

        private void FilterWeekendCols()
        {
            if (!RemoveWeekendCols) return;
            DayOfWeek[] weekendDays = { DayOfWeek.Saturday, DayOfWeek.Sunday };

            weekendDays.ToList().ForEach(day =>
            {
                var index = -1;
                do
                {
                    index = HeaderRow.FindIndex(x => x.Day == day);
                    if (index != -1)
                    {
                        HeaderRow.RemoveAt(index);
                        foreach (var row in Rows)
                        {
                            row.Cells.RemoveAt(index);
                        }
                    }
                } while (index != -1);
            });
        }

        private void FilterEmptyFirstAndLastRows()
        {
            if (!RemoveEmptyFirstAndLastRows) return;

            int start = 0;
            bool foundNotEmpty = false;

            while (!foundNotEmpty && Rows.Count > 0)
            {
                var row = Rows[start];
                var notEmptyCells = row.Cells.Count(x => x.HasValue);

                if (notEmptyCells == 0)
                {
                    Rows.RemoveAt(start);
                }
                else
                {
                    foundNotEmpty = true;
                }
            }

            foundNotEmpty = false;

            while (!foundNotEmpty && Rows.Count > 0)
            {
                int last = Rows.Count - 1;
                var row = Rows[last];
                var notEmptyCells = row.Cells.Count(x => x.HasValue);

                if (notEmptyCells == 0)
                {
                    Rows.RemoveAt(last);
                }
                else
                {
                    foundNotEmpty = true;
                }
            }
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

            // iterate days
            CalendarData.Days.ForEach(day =>
            {
                // iterate tiles
                day.Tiles.ForEach(tile =>
                {
                    bool success = false;
                    int cellNumber = 0;

                    while (!success)
                    {
                        List<CalendarCell> cells = new List<CalendarCell>();
                        int number = tile.Number;
                        int count = tile.Length;

                        // get calendar cells for tile
                        while (count > 0)
                        {
                            // Get row
                            var row = Rows.FirstOrDefault(x => x.LessonHour.Number == number);

                            if (row == null)
                            {
                                throw new ArgumentException("Missing row");
                            }

                            // get correct column values (multiple col for day)
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

                        // check already used cells
                        var c = cells.Count(x => x.HasValue);

                        // if has already used cells, then add new columns
                        if (c > 0)
                        {
                            var cell = cells[0];
                            // TODO: Checks
                            var index = Rows[0].Cells.FindIndex(x => x.Day == cell.Day);

                            // Add new row cells
                            Rows.ForEach(row =>
                            {
                                row.Cells.Insert(index + 1, new CalendarCell
                                {
                                    Day = cell.Day,
                                    Tile = null,
                                    DoTile = true,
                                    HasRowSpan = false,
                                    RowSpanNumber = 1
                                });
                            });

                            // Expand cols
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

                        // Add tiles and rowspans
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

                            cells[i].HasValue = true;
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

        private async void OnClick(CalendarCell cell)
        {
            var parameters = new DialogParameters {
                { "Cell", cell },
                { "Interval", GetIntervalForCell(cell) },
                { "OtherCells", GetOtherCells(cell) }
            };
            var dialog =
                DialogService.Show<CellInformationDialog>(cell.Tile.SubjectLongName, parameters, new DialogOptions
                {
                    MaxWidth = MaxWidth.Small,
                    FullWidth = true
                });

            var result = await dialog.Result;
        }

        private List<CalendarCourse> GetOtherCells(CalendarCell cell)
        {
            List<CalendarCourse> others = new List<CalendarCourse>();
            CalendarData.Days.ForEach(day =>
            {
                day.Tiles.ForEach(tile =>
                {
                    if (tile.CourseId != cell.Tile.CourseId && tile.SubjectId == cell.Tile.SubjectId)
                    {
                        others.Add(new CalendarCourse
                        {
                            CourseId = tile.CourseId,
                            Place = tile.Place,
                            Interval = GetInterval(tile.Number, tile.Length)
                        });
                    }
                });
            });

            return others;
        }

        private string GetIntervalForCell(CalendarCell cell)
        {
            return GetInterval(cell.Tile.Number, cell.Tile.Length);
        }

        private string GetInterval(int number, int length)
        {
            int start = number;
            int end = number + length - 1;

            LessonHourDto startHour = LessonHours.FirstOrDefault(less => less.Number == start);
            LessonHourDto endHour = LessonHours.FirstOrDefault(less => less.Number == end);

            return $"{startHour.Start} - {endHour.End}";
        }

        private void ChangeEmptyColFilter(bool value)
        {
            RemoveEmptyCols = value;
            BuildTable();
        }

        private void ChangeWeekendFilter(bool value)
        {
            RemoveWeekendCols = value;
            BuildTable();
        }

        private void ChangeEmptyFirstAndLastRowFilter(bool value)
        {
            RemoveEmptyFirstAndLastRows = value;
            BuildTable();
        }
    }
}