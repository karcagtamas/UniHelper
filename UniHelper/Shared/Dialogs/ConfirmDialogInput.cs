using System;
using System.Threading.Tasks;

namespace UniHelper.Shared.Dialogs
{
    public class ConfirmDialogInput
    {
        public string Name { get; set; }
        public Func<Task<bool>> DeleteFunction { get; set; }
    }
}