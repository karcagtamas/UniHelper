using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using UniHelper.Services;
using UniHelper.Shared.Dialogs;
using UniHelper.Shared.DTOs;

namespace UniHelper.Pages
{
    /// <summary>
    /// Period Page
    /// </summary>
    public partial class Period
    {
        /// <summary>
        /// Period Id
        /// </summary>
        /// <value>Id number</value>
        [Parameter]
        public int Id { get; set; }

        [Inject]
        private IPeriodService PeriodService { get; set; }
        
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        private PeriodDto PeriodData { get; set; }

        /// <summary>
        /// Init Period
        /// </summary>
        /// <returns>Async task</returns>
        protected override async Task OnInitializedAsync()
        {
            await GetData();
        }

        private async Task GetData()
        {
            PeriodData = await PeriodService.Get(Id);
        }

        private string GetTitle()
        {
            return PeriodData?.Name ?? "Period";
        }

        private void OpenSubject(TableRowClickEventArgs<SubjectDto> e)
        {
            NavigationManager.NavigateTo($"/periods/subjects/{e.Item.Id}");
        }

        private void OpenPeriodList()
        {
            NavigationManager.NavigateTo($"/periods");
        }

        private async void OpenPeriodDialog()
        {
            var parameters = new DialogParameters {{"Period", PeriodData}};
            var dialog = DialogService.Show<PeriodDialog>("Edit Period", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await GetData();
            }
        }

        private async void OpenDeleteDialog()
        {
            var parameters = new DialogParameters
            {
                {
                    "Input",
                    new ConfirmDialogInput
                    {
                        Name = PeriodData.Name,
                        DeleteFunction = async () => await PeriodService.Remove(PeriodData.Id)
                    }
                }
            };
            var dialog = DialogService.Show<ConfirmDialog>("Confirm Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                NavigationManager.NavigateTo("/periods");
            }
        }

        private async void OpenAddDialog()
        {
            var parameters = new DialogParameters {{"Subject", null}};
            var dialog = DialogService.Show<SubjectDialog>("Add Subject", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await GetData();
            }
        }
    }
}