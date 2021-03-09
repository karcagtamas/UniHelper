using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using UniHelper.Services;
using UniHelper.Shared.Dialogs;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.Components
{
    public partial class TaskComponent
    {
        [Parameter]
        public TaskDto TaskData { get; set; }

        [Parameter]
        public EventCallback OnRemove { get; set; }

        [Parameter]
        public EventCallback OnEdit { get; set; }

        [Inject]
        private IGlobalTaskService GlobalTaskService { get; set; }

        [Inject]
        private IPeriodTaskService PeriodTaskService { get; set; }

        [Inject]
        private ISubjectTaskService SubjectTaskService { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        private async void OpenDeleteDialog()
        {
            Func<Task<bool>> f = () => { return Task.FromResult(false); };
            if (TaskData.Type == TaskType.Global)
            {
                f = async () => await GlobalTaskService.Remove(TaskData.Id);
            }
            else if (TaskData.Type == TaskType.Period)
            {
                f = async () => await PeriodTaskService.Remove(TaskData.Id);
            }
            else if (TaskData.Type == TaskType.Subject)
            {
                f = async () => await SubjectTaskService.Remove(TaskData.Id);
            }

            var parameters = new DialogParameters
            {
                {
                    "Input",
                    new ConfirmDialogInput
                    {
                        Name = TaskData.Text,
                        DeleteFunction = f
                    }
                }
            };
            var dialog = DialogService.Show<ConfirmDialog>("Confirm Delete", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await OnRemove.InvokeAsync();
            }
        }

        private async void OpenEditDialog() {
            var parameters = new DialogParameters {{"TaskData", TaskData}};
            var dialog = DialogService.Show<TaskDialog>("Edit Task", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await OnEdit.InvokeAsync();
            }
        }
    }
}