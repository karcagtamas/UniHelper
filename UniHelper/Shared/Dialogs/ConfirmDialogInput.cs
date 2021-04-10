using System;
using System.Threading.Tasks;

namespace UniHelper.Shared.Dialogs
{
    /// <summary>
    /// Confirm Dialog Input
    /// </summary>
    public class ConfirmDialogInput
    {
        /// <summary>
        /// Confirm Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Delete function
        /// </summary>
        public Func<Task<bool>> DeleteFunction { get; set; }
    }
}