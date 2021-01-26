using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using UniHelper.Enums;
using UniHelper.Services;
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

        private void EnableEditing()
        {
            PeriodModel = new PeriodModel(PeriodData);
            PeriodContext = new EditContext(PeriodModel);
            State = PageState.Editing;
            StateHasChanged();
        }

        private void EnableRemoving()
        {
            State = PageState.Removing;
            StateHasChanged();
        }

        private async void DisableEditing(bool discard)
        {
            if (!discard)
            {
                await PeriodService.Update(PeriodData.Id, PeriodModel);
                await GetData();
            }

            State = PageState.Display;
            StateHasChanged();
        }

        private async void DisableRemoving(bool persist)
        {
            if (persist)
            {
                await PeriodService.Remove(PeriodData.Id);
                NavigationManager.NavigateTo("/periods");
            }
            else
            {
                State = PageState.Display;
                StateHasChanged();
            }
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
    }
}