using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using UniHelper.Models;

namespace UniHelper.Shared.Dialogs
{
    /// <summary>
    /// Cell Information Dialog
    /// </summary>
    public partial class CellInformationDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// Source cell
        /// </summary>
        [Parameter] public CalendarCell Cell { get; set; }

        /// <summary>
        /// Interval
        /// </summary>
        [Parameter] public string Interval { get; set; }

        /// <summary>
        /// List of other courses for the current subject
        /// </summary>
        [Parameter]
        public List<CalendarCourse> OtherCells { get; set; }

        private void Cancel()
        {
            Dialog.Cancel();
        }

        private async void OpenSubject()
        {
            Cancel();
            await JSRuntime.InvokeAsync<object>("open", $"/periods/subjects/{Cell.Tile.SubjectId}", "_blank");
        }

        private string OtherCellsString()
        {
            return String.Join("; ", OtherCells.Select(cell => $"{cell.Interval} ({cell.Place})").ToList());
        }
    }
}