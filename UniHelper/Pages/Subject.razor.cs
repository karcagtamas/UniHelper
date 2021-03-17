using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using UniHelper.Services;
using UniHelper.Shared.Dialogs;
using UniHelper.Shared.DTOs;

namespace UniHelper.Pages
{
    /// <summary>
    /// Subject Page
    /// </summary>
    public partial class Subject
    {
        /// <summary>
        /// Subject Id
        /// </summary>
        /// <value>Id number</value>
        [Parameter]
        public int Id { get; set; }

        [Inject]
        private ISubjectService SubjectService { get; set; }
        
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        
        [Inject]
        private IDialogService DialogService { get; set; }
        
        private SubjectDto SubjectData { get; set; }
        
        /// <summary>
        /// Init Subject
        /// </summary>
        /// <returns>Async task</returns>
        protected override async Task OnInitializedAsync()
        {
            await GetData();
        }

        private async Task GetData()
        {
            SubjectData = await SubjectService.Get(Id);
        }

        private string GetTitle()
        {
            return SubjectData?.LongName ?? "Subject";
        }

        private void OpenCourse(TableRowClickEventArgs<CourseDto> e)
        {
            NavigationManager.NavigateTo($"/periods/subjects/courses/{e.Item.Id}");
        }

        private void OpenPeriod()
        {
            NavigationManager.NavigateTo($"/periods/{SubjectData.PeriodId}");
        }
        
        private async void OpenSubjectDialog()
        {
            var parameters = new DialogParameters {{"Subject", SubjectData}};
            var dialog = DialogService.Show<SubjectDialog>("Edit Subject", parameters);
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
                        Name = SubjectData.LongName,
                        DeleteFunction = async () => await SubjectService.Remove(SubjectData.Id)
                    }
                }
            };
            var dialog = DialogService.Show<ConfirmDialog>("Confirm Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                NavigationManager.NavigateTo($"/periods/{SubjectData.PeriodId}");
            }
        }
        
        private async void OpenAddDialog()
        {
            var parameters = new DialogParameters {{"Course", null}};
            var dialog = DialogService.Show<CourseDialog>("Add Course", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await GetData();
            }
        }
    }
}