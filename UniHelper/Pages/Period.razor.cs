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
    public partial class Period
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        private IPeriodService PeriodService { get; set; }

        [Inject]
        private ISubjectService SubjectService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        private PageState State { get; set; } = PageState.Display;

        private EditContext PeriodContext { get; set; }

        private PeriodModel PeriodModel { get; set; }

        private EditContext SubjectContext { get; set; }

        private SubjectModel SubjectModel { get; set; }

        private PeriodDto PeriodData { get; set; }

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

        private void EnableSubjectAdding()
        {
            SubjectModel = new SubjectModel(PeriodData.Id);
            SubjectContext = new EditContext(SubjectModel);
            State = PageState.Adding;
            StateHasChanged();
        }

        private async void DisabledSubjectAdding(bool discard)
        {
            if (!discard)
            {
                await SubjectService.Create(SubjectModel);
                await GetData();
            }

            State = PageState.Display;
            StateHasChanged();
        }

        private void OpenSubject(int id)
        {
            NavigationManager.NavigateTo($"/periods/subjects/{id}");
        }

        private void OpenPeriodList()
        {
            NavigationManager.NavigateTo($"/periods");
        }

        private async void OpenPeriodDialog()
        {
            var parameters = new DialogParameters();
            parameters.Add("Period", PeriodData);
            var dialog = DialogService.Show<PeriodDialog>("Edit Period", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await GetData();
            }
        }

        private async void OpenDeleteDialog()
        {
            var parameters = new DialogParameters();
            parameters.Add("Input", new ConfirmDialogInput
            {
                Name = PeriodData.Name,
                DeleteFunction = async () => { return await PeriodService.Remove(PeriodData.Id); }
            });
            var dialog = DialogService.Show<PeriodDialog>("Edit Period", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                NavigationManager.NavigateTo("/periods");
            }
        }
    }
}