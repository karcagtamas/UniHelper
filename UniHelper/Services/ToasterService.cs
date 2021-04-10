using Karcags.Blazor.Common.Enums;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using MudBlazor;

namespace UniHelper.Services
{
    /// <summary>
    /// Toaster Service
    /// </summary>
    public class ToasterService : IToasterService
    {
        private readonly ISnackbar _snackbar;

        /// <summary>
        /// Init Toaster Service
        /// </summary>
        /// <param name="snackbar">Snackbar service</param>
        public ToasterService(ISnackbar snackbar)
        {
            _snackbar = snackbar;
        }

        /// <summary>
        /// Open toaster
        /// </summary>
        /// <param name="settings">Toaster Settings</param>
        public void Open(ToasterSettings settings)
        {
            _snackbar.Add(GenerateString(settings), GetType(settings));
        }

        private string GenerateString(ToasterSettings settings)
        {
            return $"<h5>{settings.Caption}</h5><h6>{settings.Message}</h6>";
        }

        private Severity GetType(ToasterSettings settings)
        {
            Severity type = Severity.Normal;
            switch (settings.Type)
            {
                case ToasterType.Success:
                    type = Severity.Success;
                    break;
                case ToasterType.Error:
                    type = Severity.Error;
                    break;
                case ToasterType.Warning:
                    type = Severity.Warning;
                    break;
                case ToasterType.Info:
                    type = Severity.Info;
                    break;
            }

            return type;
        }
    }
}