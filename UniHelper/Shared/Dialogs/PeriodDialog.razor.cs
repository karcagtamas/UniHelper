using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using UniHelper.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Shared.Dialogs
{
    public partial class PeriodDialog
    {
        [CascadingParameter]
        private MudDialogInstance Dialog { get; set; }

        [Parameter]
        public PeriodDto Period { get; set; }

        [Inject]
        private IPeriodService PeriodService { get; set; }
        private EditContext PeriodContext { get; set; }
        private PeriodModel Model { get; set; }

        protected override Task OnInitializedAsync()
        {
            if (Period != null)
            {
                Model = new PeriodModel(Period);
            }
            else
            {
                Model = new PeriodModel();
            }
            PeriodContext = new EditContext(Model);
            return base.OnInitializedAsync();
        }

        private async void Save()
        {
            if (PeriodContext.Validate())
            {
                Model.Start = Model.Start.ToLocalTime();
                Model.End = Model.End.ToLocalTime();
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