using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Microsoft.AspNetCore.Components;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <inheritdoc />
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpService _httpService;
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;

        private string Url { get; set; } = ApplicationSettings.BaseApiUrl + "/auth";

        public StorageUser User { get; set; }

        /// <summary>
        /// Init Authentication Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        /// <param name="localStorageService">Local Storage Service</param>
        /// <param name="navigationManager">Navigation Manager</param>
        public AuthenticationService(IHttpService httpService, ILocalStorageService localStorageService,
            NavigationManager navigationManager)
        {
            _httpService = httpService;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
            Initialize();
        }

        /// <inheritdoc />
        public async Task<bool> Login(LoginModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("login", -1);

            var settings = new HttpSettings(Url, null, pathParams, "Login");

            var body = new HttpBody<LoginModel>(model);

            User = await _httpService.CreateWithResult<StorageUser, LoginModel>(settings, body);

            if (User == null) return false;
            
            await _localStorageService.SetItemAsync("user", User);
            await _localStorageService.SetItemAsync("token", User.Token);
            return true;
        }

        /// <inheritdoc />
        public async Task<bool> Registration(RegistrationModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("registration", -1);

            var settings = new HttpSettings(Url, null, pathParams, "Registration");

            var body = new HttpBody<RegistrationModel>(model);

            return await _httpService.Create(settings, body);
        }

        /// <inheritdoc />
        public bool IsLoggedIn()
        {
            return User != null;
        }

        /// <inheritdoc />
        public async void Logout()
        {
            User = null;
            await _localStorageService.RemoveItemAsync("user");
            await _localStorageService.RemoveItemAsync("token");
            _navigationManager.NavigateTo("login");
        }

        /// <inheritdoc />
        public async void Initialize()
        {
            User = await _localStorageService.GetItemAsync<StorageUser>("user");
        }
    }
}