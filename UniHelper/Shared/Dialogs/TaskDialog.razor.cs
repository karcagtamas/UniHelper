using System.Collections.Generic;
using System.Linq;
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
        
        [Inject]
        private IPeriodService PeriodService { get; set; }
        
        [Inject]
        private ISubjectService SubjectService { get; set; }

        private TaskType AddType { get; set; }
        private EditContext TaskContext { get; set; }
        private TaskModel Model { get; set; }
        private bool IsEdit { get; set; }
        private int ParentSelectedId { get; set; }
        private int SelectedId { get; set; }
        private List<PeriodDto> Periods { get; set; }
        private List<SubjectDto> SourceSubjects { get; set; }
        private List<SubjectDto> Subjects { get; set; }

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

        private async void TypeChanged(TaskType type)
        {
            Periods = new List<PeriodDto>();
            SourceSubjects = new List<SubjectDto>();
            switch (type)
            {
                case TaskType.Period:
                    Periods = await PeriodService.GetList();
                    break;
                case TaskType.Subject:
                    Periods = await PeriodService.GetList();
                    SourceSubjects = await SubjectService.GetList();
                    break;
            }
            AddType = type;
            StateHasChanged();
        }

        private void ParentIdChanged(int id)
        {
            Subjects = new List<SubjectDto>();
            if (SourceSubjects != null)
            {
                Subjects = SourceSubjects.Where(x => x.PeriodId == id).ToList();
            }
            ParentSelectedId = id;
            StateHasChanged();
        }

        private async void Save()
        {
            if ((AddType == TaskType.Period || AddType == TaskType.Subject) && SelectedId == 0)
            {
                return;
            }

            if (!TaskContext.Validate()) return;
            
            switch (AddType)
            {
                case TaskType.Global when IsEdit:
                {
                    if (await GlobalTaskService.Update(TaskData.Id, new GlobalTaskModel(Model)))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }

                    break;
                }
                case TaskType.Global:
                {
                    if (await GlobalTaskService.Create(new GlobalTaskModel(Model)))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }

                    break;
                }
                case TaskType.Period when IsEdit:
                {
                    if (await PeriodTaskService.Update(TaskData.Id, new PeriodTaskModel(SelectedId, Model)))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }

                    break;
                }
                case TaskType.Period:
                {
                    if (await PeriodTaskService.Create(new PeriodTaskModel(SelectedId, Model)))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }

                    break;
                }
                case TaskType.Subject when IsEdit:
                {
                    if (await SubjectTaskService.Update(TaskData.Id, new SubjectTaskModel(SelectedId, Model)))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }

                    break;
                }
                case TaskType.Subject:
                {
                    if (await SubjectTaskService.Create(new SubjectTaskModel(SelectedId, Model)))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }

                    break;
                }
            }
        }

        private void Cancel()
        {
            Dialog.Cancel();
        }
    }
}