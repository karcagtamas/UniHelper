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
    /// <summary>
    /// Task Dialog
    /// </summary>
    public partial class TaskDialog
    {
        [CascadingParameter] private MudDialogInstance Dialog { get; set; }

        /// <summary>
        /// Task Data
        /// </summary>
        [Parameter]
        public TaskDto TaskData { get; set; }

        /// <summary>
        /// Init Selected Id
        /// </summary>
        [Parameter]
        public List<int> InitId { get; set; }

        [Inject] private IGlobalTaskService GlobalTaskService { get; set; }

        [Inject] private IPeriodTaskService PeriodTaskService { get; set; }

        [Inject] private ISubjectTaskService SubjectTaskService { get; set; }

        [Inject] private IPeriodService PeriodService { get; set; }

        [Inject] private ISubjectService SubjectService { get; set; }
        
        [Inject] private IStoreService StoreService { get; set; }

        private TaskType AddType { get; set; }
        private EditContext TaskContext { get; set; }
        private TaskModel Model { get; set; }
        private bool IsEdit { get; set; }
        private int ParentSelectedId { get; set; }
        private int SelectedId { get; set; }
        private List<PeriodDto> Periods { get; set; }
        private List<SubjectDto> SourceSubjects { get; set; }
        private List<SubjectDto> Subjects { get; set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            if (TaskData != null)
            {
                Model = new TaskModel(TaskData);
                TaskContext = new EditContext(Model);
                IsEdit = true;
                AddType = TaskData.Type;

                if (InitId != null && InitId.Count > 0)
                {
                    if (TaskData.Type == TaskType.Period)
                    {
                        await TypeChanged(TaskType.Period, false);
                        SelectedId = InitId[0];
                    }
                    else if (TaskData.Type == TaskType.Subject)
                    {
                        await TypeChanged(TaskType.Subject, false);
                        ParentIdChanged(InitId[0]);
                        SelectedId = InitId[1];
                    }
                }
            }
            else
            {
                Model = new TaskModel();
                TaskContext = new EditContext(Model);
                AddType = TaskType.Global;
            }

            await base.OnInitializedAsync();
            StateHasChanged();
        }

        private async Task TypeChanged(TaskType type, bool refreshState)
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

            if (refreshState)
            {
                StateHasChanged();
            }
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
                    var userId = StoreService.Get<StorageUser>("user")?.Id ?? -1;
                    if (await GlobalTaskService.Update(TaskData.Id, new GlobalTaskModel(Model, userId)))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }

                    break;
                }
                case TaskType.Global:
                {
                    var userId = StoreService.Get<StorageUser>("user")?.Id ?? -1;
                    if (await GlobalTaskService.Create(new GlobalTaskModel(Model, userId)))
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