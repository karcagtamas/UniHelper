using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using UniHelper.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Shared.Dialogs
{
    public partial class SubjectDialog
    {
        [CascadingParameter]
        private MudDialogInstance Dialog { get; set; }

        [Parameter]
        public SubjectDto Subject { get; set; }

        [Inject]
        private ISubjectService SubjectService { get; set; }
        private EditContext SubjectContext { get; set; }
        private SubjectModel Model { get; set; }
        private bool IsEdit { get; set; }

        protected override Task OnInitializedAsync()
        {
            if (Subject != null)
            {
                Model = new SubjectModel(Subject);
                IsEdit = true;
            }
            else
            {
                Model = new SubjectModel();
            }
            SubjectContext = new EditContext(Model);
            return base.OnInitializedAsync();
        }

        private async void Save()
        {
            if (SubjectContext.Validate())
            {
                if (IsEdit)
                {
                    if (await SubjectService.Update(Subject.Id, Model))
                    {
                        Dialog.Close(DialogResult.Ok(true));
                    }
                }
                else
                {
                    if (await SubjectService.Create(Model))
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