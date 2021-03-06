using System;
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
    public partial class Subject
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        private ISubjectService SubjectService { get; set; }
        
        [Inject]
        private ICourseService CourseService { get; set; }
        
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        
        [Inject]
        private IDialogService DialogService { get; set; }
        
        private SubjectDto SubjectData { get; set; }

        private EditContext CourseContext { get; set; }
        
        private CourseModel CourseModel { get; set; }

        private PageState State { get; set; } = PageState.Display;
        
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
                NavigationManager.NavigateTo("/subjects");
            }
        }
        
        private async void OpenAddDialog()
        {
            var parameters = new DialogParameters {{"Course", null}};
            var dialog = DialogService.Show<SubjectDialog>("Add Course", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await GetData();
            }
        }
        
    }
}