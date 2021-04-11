using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace UniHelper.Shared.Dialogs
{
    /// <summary>
    /// Confirm Dialog
    /// </summary>
    public partial class ConfirmDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Dialog Input
        /// </summary>
        [Parameter]
        public ConfirmDialogInput Input { get; set; }

        private async void Confirm()
        {
            if (await Input.DeleteFunction())
            {
                Dialog.Close(DialogResult.Ok(true));
            }
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}