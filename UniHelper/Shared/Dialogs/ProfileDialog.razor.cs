using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace UniHelper.Shared.Dialogs
{
    /// <summary>
    /// About Dialog
    /// </summary>
    public partial class ProfileDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }
        
        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}