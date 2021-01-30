using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using UniHelper.Enums;
using UniHelper.Services;
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

        private PageState State { get; set; } = PageState.Display;
        
        private EditContext PeriodContext { get; set; }
        
        private PeriodModel Model { get; set; }

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

        private void OpenPeriod(int id)
        {
            NavigationManager.NavigateTo($"/periods/{id}");
        }

        private void EnableAdding()
        {
            Model = new PeriodModel();
            PeriodContext = new EditContext(Model);
            State = PageState.Adding;
            StateHasChanged();
        }

        private async void DisableAdding(bool discard)
        {
            if (!discard)
            {
                Model.Start = Model.Start.ToLocalTime();
                Model.End = Model.End.ToLocalTime();
                await PeriodService.Create(Model);
                await Refresh();
            }
            
            State = PageState.Display;
            StateHasChanged();
        }

        private async void ChangeCurrent(int id)
        {
            SelectedPeriod = id;
            await PeriodService.SetCurrent(id);
            await Refresh();
        }
    }
}