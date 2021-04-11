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
        private readonly IStoreService _storeService;

        private string Url { get; set; } = ApplicationSettings.BaseApiUrl + "/auth";

        /// <summary>
        /// Init Authentication Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        /// <param name="localStorageService">Local Storage Service</param>
        /// <param name="navigationManager">Navigation Manager</param>
        /// <param name="storeService">Store Service</param>
        public AuthenticationService(IHttpService httpService, ILocalStorageService localStorageService,
            NavigationManager navigationManager, IStoreService storeService)
        {
            _httpService = httpService;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
            _storeService = storeService;
        }

        /// <inheritdoc />
        public async Task<bool> Login(LoginModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("login", -1);

            var settings = new HttpSettings(Url, null, pathParams, "Login");

            var body = new HttpBody<LoginModel>(model);

            var user = await _httpService.CreateWithResult<StorageUser, LoginModel>(settings, body);

            if (user == null) return false;
            
            await _localStorageService.SetItemAsync("user", user);
            await _localStorageService.SetItemAsync("token", user.Token);
            _storeService.Add("user", user);
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
            return _storeService.IsExists("user");
        }

        /// <inheritdoc />
        public async void Logout()
        {
            await _localStorageService.RemoveItemAsync("user");
            await _localStorageService.RemoveItemAsync("token");
            _storeService.Remove("user");
            _navigationManager.NavigateTo("login");
        }

        private async Task<StorageUser> GetUser()
        {
            return await _localStorageService.GetItemAsync<StorageUser>("user");
        }

        private async Task<string> GetToken()
        {
            return await _localStorageService.GetItemAsync<string>("token");
        }
    }
}