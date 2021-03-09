using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using UniHelper.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Enums;
using UniHelper.Shared.Models;

namespace UniHelper.Shared.Dialogs
{
    public partial class TaskDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        [Parameter] public TaskDto TaskData { get; set; }

        [Inject]
        private IGlobalTaskService GlobalTaskService { get; set; }

        [Inject]
        private IPeriodTaskService PeriodTaskService { get; set; }

        [Inject]
        private ISubjectTaskService SubjectTaskService { get; set; }

        private TaskType AddType { get; set; }
        private EditContext TaskContext { get; set; }
        private TaskModel Model { get; set; }
        private bool IsEdit { get; set; }
        private int SelectedId { get; set; }

        protected override Task OnInitializedAsync()
        {
            if (TaskData != null)
            {
                Model = new TaskModel(TaskData);
                IsEdit = true;
                AddType = TaskData.Type;
            }
            else
            {
                Model = new TaskModel();
                AddType = TaskType.Global;
            }
            TaskContext = new EditContext(Model);
            return base.OnInitializedAsync();
        }

        private async void Save()
        {
            if (TaskContext.Validate())
            {
                if (AddType == TaskType.Global)
                {
                    if (IsEdit)
                    {
                        if (await GlobalTaskService.Update(TaskData.Id, new GlobalTaskModel(Model)))
                        {
                            Dialog.Close(DialogResult.Ok(true));
                        }
                    }
                    else
                    {
                        if (await GlobalTaskService.Create(new GlobalTaskModel(Model)))
                        {
                            Dialog.Close(DialogResult.Ok(true));
                        }
                    }
                }
                else if (AddType == TaskType.Period)
                {
                    if (IsEdit)
                    {
                        if (await PeriodTaskService.Update(TaskData.Id, new PeriodTaskModel(SelectedId, Model)))
                        {
                            Dialog.Close(DialogResult.Ok(true));
                        }
                    }
                    else
                    {
                        if (await PeriodTaskService.Create(new PeriodTaskModel(SelectedId, Model)))
                        {
                            Dialog.Close(DialogResult.Ok(true));
                        }
                    }
                }
                else if (AddType == TaskType.Subject)
                {
                    if (IsEdit)
                    {
                        if (await SubjectTaskService.Update(TaskData.Id, new SubjectTaskModel(SelectedId, Model)))
                        {
                            Dialog.Close(DialogResult.Ok(true));
                        }
                    }
                    else
                    {
                        if (await SubjectTaskService.Create(new SubjectTaskModel(SelectedId, Model)))
                        {
                            Dialog.Close(DialogResult.Ok(true));
                        }
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