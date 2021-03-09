using System.Collections.Generic;
using System.Linq;
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
    public partial class Tasks
    {
        [Inject]
        private IGlobalTaskService GlobalTaskService { get; set; }
        
        [Inject]
        private IPeriodTaskService PeriodTaskService { get; set; }
        
        [Inject]
        private ISubjectTaskService SubjectTaskService { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        private List<TaskDto> TaskList { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await GetLists();
        }

        private async Task GetLists()
        {
            var list = new List<TaskDto>();
            list.AddRange(await GlobalTaskService.GetList());
            list.AddRange(await PeriodTaskService.GetList());
            list.AddRange(await SubjectTaskService.GetList());
            list = list.OrderBy(x => x.IsSolved).ThenBy(x => x.DueDate).ThenByDescending(x => x.Priority).ToList();
            
            TaskList = list;
            StateHasChanged();
        }

        private async void OpenAddDialog()
        {
            var parameters = new DialogParameters {{"TaskData", null}};
            var dialog = DialogService.Show<TaskDialog>("Add Task", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await GetLists();
            }
        }
    }
}