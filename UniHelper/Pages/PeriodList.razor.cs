using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using UniHelper.Enums;
using UniHelper.Services;
using UniHelper.Shared.Dialogs;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Pages
{
    public partial class PeriodList
    {
        [Inject]
        private IPeriodService PeriodService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IDialogService DialogService {get;set;}

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

        private void OpenDialog() {
            DialogService.Show<PeriodDialog>();
        }
    }
}