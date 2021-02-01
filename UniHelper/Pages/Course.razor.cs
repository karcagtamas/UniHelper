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
    public partial class Course
    {
        [Parameter]
        public int Id { get; set; }
        
        [Inject]
        private ICourseService CourseService { get; set; }
        
        [Inject]
        private ILessonHourService LessonHourService { get; set; }
        
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        
        private CourseDto CourseData { get; set; }
        
        private EditContext CourseContext { get; set; }
        
        private CourseModel CourseModel { get; set; }

        private PageState State { get; set; } = PageState.Display;
        
        private LessonHourIntervalDto Interval { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            await GetData();
        }

        private async Task GetData()
        {
            CourseData = await CourseService.Get(Id);
            Interval = await LessonHourService.GetHourInterval(CourseData.Number,
                CourseData.Number + CourseData.Length - 1);
        }

        private string GetTitle()
        {
            return CourseData?.Place ?? "Course";
        }
        
        private void EnableEditing()
        {
            CourseModel = new CourseModel(CourseData);
            CourseContext = new EditContext(CourseModel);
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
                await CourseService.Update(CourseData.Id, CourseModel);
                await GetData();
            }

            State = PageState.Display;
            StateHasChanged();
        }

        private async void DisableRemoving(bool persist)
        {
            if (persist)
            {
                await CourseService.Remove(CourseData.Id);
                NavigationManager.NavigateTo($"/periods/subjects/{CourseData.SubjectId}");
            }
            else
            {
                State = PageState.Display;
                StateHasChanged();
            }
        }

        private void OpenSubject()
        {
            NavigationManager.NavigateTo($"/periods/subjects/{CourseData.SubjectId}");
        }
    }
}