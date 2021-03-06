using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using UniHelper.Services;
using UniHelper.Shared.Dialogs;
using UniHelper.Shared.DTOs;

namespace UniHelper.Pages
{
    public partial class PeriodList
    {
        [Inject]
        private IPeriodService PeriodService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        private List<PeriodDto> List { get; set; } = new();

        private int SelectedPeriod { get; set; } = -1;

        protected override async Task OnInitializedAsync()
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            this.List = await PeriodService.GetList();
            SelectedPeriod = await PeriodService.GetCurrent();
            StateHasChanged();
        }

        private void OpenPeriod(TableRowClickEventArgs<PeriodDto> e)
        {
            NavigationManager.NavigateTo($"/periods/{e.Item.Id}");
        }

        private async void ChangeCurrent(int id)
        {
            SelectedPeriod = id;
            await PeriodService.SetCurrent(id);
            await Refresh();
        }

        private async void OpenDialog()
        {
            var parameters = new DialogParameters {{"Period", null}};
            var dialog = DialogService.Show<PeriodDialog>("Add Period", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await Refresh();
            }
        }
    }
}