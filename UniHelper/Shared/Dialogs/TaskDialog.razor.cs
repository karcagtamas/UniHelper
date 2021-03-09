using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using UniHelper.Enums;
using UniHelper.Services;
using UniHelper.Shared.DTOs;
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
            }
            else
            {
                Model = new TaskModel();
            }
            TaskContext = new EditContext(Model);
            AddType = TaskType.Global;
            return base.OnInitializedAsync();
        }

        private async void Save()
        {
            if (TaskContext.Validate())
            {
                if (IsEdit)
                {
                    if (await GlobalTaskService.Update(TaskData.Id, (GlobalTaskModel)Model))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }
                }
                else
                {
                    if (await GlobalTaskService.Create((GlobalTaskModel)Model))
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