using Microsoft.AspNetCore.Components.Forms;
using UniHelper.Shared.Models;

namespace UniHelper.Pages
{
    /// <summary>
    /// Login Page
    /// </summary>
    public partial class Login
    {
        private EditContext LoginContext { get; set; }
        private LoginModel Model { get; set; }

        /// <summary>
        /// On Init
        /// </summary>
        protected override void OnInitialized()
        {
            Model = new LoginModel();
            LoginContext = new EditContext(Model);
            base.OnInitialized();
        }

        private void SignIn() 
        {

        }
    }
}