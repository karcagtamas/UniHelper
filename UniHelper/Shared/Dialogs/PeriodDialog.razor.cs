using System.Threading.Tasks;
using KarcagS.Blazor.Common.Store;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using UniHelper.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Shared.Dialogs
{
    /// <summary>
    /// Period Dialog
    /// </summary>
    public partial class PeriodDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Period Data
        /// </summary>
        [Parameter]
        public PeriodDto Period { get; set; }

        [Inject] private IPeriodService PeriodService { get; set; }
        
        [Inject]
        private IStoreService StoreService { get; set; }
        private EditContext PeriodContext { get; set; }
        private PeriodModel Model { get; set; }
        private bool IsEdit { get; set; }

        /// <inheritdoc />
        protected override Task OnInitializedAsync()
        {
            if (Period != null)
            {
                Model = new PeriodModel(Period);
                IsEdit = true;
            }
            else
            {
                var userId = StoreService.Get<StorageUser>("user")?.Id ?? -1;
                Model = new PeriodModel(userId);
            }

            PeriodContext = new EditContext(Model);
            return base.OnInitializedAsync();
        }

        private async void Save()
        {
            if (!PeriodContext.Validate()) return;
            if (IsEdit)
            {
                if (await PeriodService.Update(Period.Id, Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
            else
            {
                if (await PeriodService.Create(Model))
                {
                    Dialog.Close(DialogResult.Ok(true));
                }
            }
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}