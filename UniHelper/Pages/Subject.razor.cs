using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using UniHelper.Enums;
using UniHelper.Services;
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
        
        private SubjectDto SubjectData { get; set; }
        
        private EditContext SubjectContext { get; set; }
        
        private SubjectModel SubjectModel { get; set; }
        
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
        
        private void EnableEditing()
        {
            SubjectModel = new SubjectModel(SubjectData);
            SubjectContext = new EditContext(SubjectModel);
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
                await SubjectService.Update(SubjectData.Id, SubjectModel);
                await GetData();
            }

            State = PageState.Display;
            StateHasChanged();
        }

        private async void DisableRemoving(bool persist)
        {
            if (persist)
            {
                await SubjectService.Remove(SubjectData.Id);
                NavigationManager.NavigateTo($"/periods/{SubjectData.PeriodId}");
            }
            else
            {
                State = PageState.Display;
                StateHasChanged();
            }
        }
        
        private void EnableCourseAdding()
        {
            CourseModel = new CourseModel(SubjectData.Id);
            CourseContext = new EditContext(CourseModel);
            State = PageState.Adding;
            StateHasChanged();
        }

        private async void DisabledCourseAdding(bool discard)
        {
            if (!discard)
            {
                await CourseService.Create(CourseModel);
                await GetData();
            }

            State = PageState.Display;
            StateHasChanged();
        }
        
        private void OpenCourse(int id)
        {
            NavigationManager.NavigateTo($"/periods/subjects/courses/{id}");
        }
    }
}