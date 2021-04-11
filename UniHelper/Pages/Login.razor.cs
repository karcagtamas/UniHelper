using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using UniHelper.Helpers;
using UniHelper.Services;
using UniHelper.Shared.Models;

namespace UniHelper.Pages
{
    /// <summary>
    /// Login Page
    /// </summary>
    public partial class Login
    {
        [Inject] private IAuthenticationService AuthenticationService { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }
        private EditContext LoginContext { get; set; }
        private LoginModel Model { get; set; }

        private bool _isShow = false;
        private InputType _passwordInput = InputType.Password;
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

        /// <summary>
        /// On Init
        /// </summary>
        protected override void OnInitialized()
        {
            Model = new LoginModel();
            LoginContext = new EditContext(Model);
            base.OnInitialized();
            if (AuthenticationService.IsLoggedIn())
            {
                NavigationManager.NavigateTo("/");
            }
        }

        private async void SignIn()
        {
            if (!LoginContext.Validate()) return;
            if (!await AuthenticationService.Login(Model)) return;
            var returnUrl = NavigationManager.QueryString("returnUrl") ?? "/";
            NavigationManager.NavigateTo(returnUrl);
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