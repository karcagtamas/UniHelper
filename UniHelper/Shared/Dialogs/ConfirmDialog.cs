using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace UniHelper.Shared.Dialogs
{
    public partial class ConfirmDialog
    {

        [CascadingParameter]
        private MudDialogInstance Dialog { get; set; }

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