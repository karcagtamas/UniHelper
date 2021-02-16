using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using UniHelper.Enums;
using UniHelper.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Pages
{
    public partial class Tasks
    {
        [Inject]
        private IGlobalTaskService GlobalTaskService { get; set; }
        
        [Inject]
        private IPeriodTaskService PeriodTaskService { get; set; }
        
        [Inject]
        private ISubjectTaskService SubjectTaskService { get; set; }
        
        private TaskModel TaskModel { get; set; }
        private EditContext TaskContext { get; set; }
        private TaskType AddType { get; set; }
        private PageState State { get; set; } = PageState.Display;
        private List<TaskDto> TaskList { get; set; }
        private int SelectedId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetLists();
        }

        private async Task GetLists()
        {
            TaskList = new List<TaskDto>();
            TaskList.AddRange(await GlobalTaskService.GetList());
        }

        private void EnableAdding()
        {
            TaskModel = new TaskModel();
            TaskContext = new EditContext(TaskModel);
            AddType = TaskType.Global;
            State = PageState.Adding;
            StateHasChanged();
        }

        private async void DisableAdding(bool discard)
        {
            if (!discard)
            {
                if (AddType == TaskType.Global)
                {
                    await GlobalTaskService.Create(new GlobalTaskModel(TaskModel));
                } else if (AddType == TaskType.Period)
                {
                    await PeriodTaskService.Create(new PeriodTaskModel(SelectedId, TaskModel));
                } else if (AddType == TaskType.Subject)
                {
                    await SubjectTaskService.Create(new SubjectTaskModel(SelectedId, TaskModel));
                }
                
                await GetLists();
            }

            State = PageState.Display;
            StateHasChanged();
        }
    }
}