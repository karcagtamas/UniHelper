using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using UniHelper.Services;
using UniHelper.Shared.Dialogs;
using UniHelper.Shared.DTOs;

namespace UniHelper.Pages
{
    /// <summary>
    /// Course page
    /// </summary>
    public partial class Course
    {
        /// <summary>
        /// Course Id
        /// </summary>
        /// <value>Id number</value>
        [Parameter]
        public int Id { get; set; }

        [Inject] private ICourseService CourseService { get; set; }

        [Inject] private ILessonHourService LessonHourService { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IDialogService DialogService { get; set; }

        private CourseDto CourseData { get; set; }

        private LessonHourIntervalDto Interval { get; set; }

        /// <summary>
        /// Init Course
        /// </summary>
        /// <returns></returns>
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

        private void OpenSubject()
        {
            NavigationManager.NavigateTo($"/periods/subjects/{CourseData.SubjectId}");
        }

        private async void OpenCourseDialog()
        {
            var parameters = new DialogParameters {{"Course", CourseData}};
            var dialog = DialogService.Show<CourseDialog>("Edit Course", parameters);
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
                        Name = CourseData.Place,
                        DeleteFunction = async () => await CourseService.Remove(CourseData.Id)
                    }
                }
            };
            var dialog = DialogService.Show<ConfirmDialog>("Confirm Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                NavigationManager.NavigateTo($"/periods/subjects/{CourseData.SubjectId}");
            }
        }
    }
}