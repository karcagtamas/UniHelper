using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using UniHelper.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Shared.Dialogs
{
    /// <summary>
    /// Course Dialog
    /// </summary>
    public partial class CourseDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Course Data
        /// </summary>
        [Parameter]
        public CourseDto Course { get; set; }
        
        /// <summary>
        /// Subject Id
        /// </summary>
        [Parameter]
        public int SubjectId { get; set; }

        [Inject] private ICourseService CourseService { get; set; }
        private EditContext CourseContext { get; set; }
        private CourseModel Model { get; set; }
        private bool IsEdit { get; set; }

        /// <inheritdoc />
        protected override Task OnInitializedAsync()
        {
            if (Course != null)
            {
                Model = new CourseModel(Course);
                IsEdit = true;
            }
            else
            {
                Model = new CourseModel(SubjectId);
            }

            CourseContext = new EditContext(Model);
            return base.OnInitializedAsync();
        }

        private async void Save()
        {
            if (CourseContext.Validate())
            {
                if (IsEdit)
                {
                    if (await CourseService.Update(Course.Id, Model))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }
                }
                else
                {
                    if (await CourseService.Create(Model))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }
                }
            }
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}