using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using UniHelper.Models;
using UniHelper.Services;
using UniHelper.Shared.Models;

namespace UniHelper.Pages
{
    /// <summary>
    /// Registration Page
    /// </summary>
    public partial class Registration
    {
        [Inject] private IAuthenticationService AuthenticationService { get; set; }
        private EditContext RegistrationContext { get; set; }
        private RegistrationInputModel Model { get; set; }

        private bool _isShow = false;
        private InputType _passwordInput = InputType.Password;
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

        /// <summary>
        /// On Init
        /// </summary>
        protected override void OnInitialized()
        {
            Model = new RegistrationInputModel();
            RegistrationContext = new EditContext(Model);
            base.OnInitialized();
        }

        private async void SignUp()
        {
            if (RegistrationContext.Validate())
            {
                await AuthenticationService.Registration(new RegistrationModel
                {
                    Email = Model.Email,
                    FullName = Model.FullName,
                    Password = Model.Password,
                    UserName = Model.UserName
                });
            }
        }

        private void SwitchPassword()
        {
            if (_isShow)
            {
                _isShow = false;
                _passwordInput = InputType.Password;
                _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
            }
            else
            {
                _isShow = true;
                _passwordInput = InputType.Text;
                _passwordInputIcon = Icons.Material.Filled.Visibility;
            }
        }
    }
}