using System;
using System.Linq;
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
        [Parameter] public TaskDto TaskData { get; set; }

        [Parameter] public EventCallback OnRemove { get; set; }

        [Parameter] public EventCallback OnEdit { get; set; }

        [Inject] private IGlobalTaskService GlobalTaskService { get; set; }

        [Inject] private IPeriodTaskService PeriodTaskService { get; set; }

        [Inject] private ISubjectTaskService SubjectTaskService { get; set; }

        [Inject] private IDialogService DialogService { get; set; }

        private string _defaultClass = "d-flex flex-column align-center justify-center mud-width-full py-8";

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

        private async void OpenEditDialog()
        {
            var parameters = new DialogParameters {{"TaskData", TaskData}};
            var dialog = DialogService.Show<TaskDialog>("Edit Task", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await OnEdit.InvokeAsync();
            }
        }

        private string GetClass()
        {
            var val = "";

            if (TaskData.IsSolved)
            {
                val += " task-solved";
            }
            else
            {
                switch (TaskData.Priority)
                {
                    case TaskPriority.High:
                        val += " task-high";
                        break;
                    case TaskPriority.Important:
                        val += " task-important";
                        break;
                    case TaskPriority.Normal:
                        val += " task-normal";
                        break;
                    case TaskPriority.Low:
                        val += " task-low";
                        break;
                }
                
                if (DateTime.Now > TaskData.DueDate)
                {
                    val += " task-ended";
                }
            }
            
            return _defaultClass + val;
        }
    }
}