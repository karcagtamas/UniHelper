using System;
using Microsoft.AspNetCore.Components;
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

        /// <summary>
        /// Source cell
        /// </summary>
        [Parameter] public CalendarCell Cell { get; set; }

        /// <summary>
        /// Interval
        /// </summary>
        [Parameter] public string Interval { get; set; }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}