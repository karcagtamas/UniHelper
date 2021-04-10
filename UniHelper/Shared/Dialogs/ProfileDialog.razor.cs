using Microsoft.AspNetCore.Components;
using MudBlazor;
using UniHelper.Services;
using UniHelper.Shared.Models;

namespace UniHelper.Shared.Dialogs
{
    /// <summary>
    /// About Dialog
    /// </summary>
    public partial class ProfileDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }
        
        [Inject] private IStoreService StoreService { get; set; }
        
        private StorageUser User { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            User = StoreService.Get<StorageUser>("user");
            base.OnInitialized();
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}