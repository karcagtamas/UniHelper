using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;
using KarcagS.Blazor.Common.Store;
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
            var settings = new HttpSettings(_httpService.BuildUrl(Url, "login")).AddToaster("Login");

            var body = new HttpBody<LoginModel>(model);

            var user = await _httpService.PostWithResult<StorageUser, LoginModel>(settings, body).ExecuteWithResult();

            if (user == null) return false;
            
            await _localStorageService.SetItemAsync("user", user);
            await _localStorageService.SetItemAsync("token", user.Token);
            _storeService.Add("user", user);
            return true;
        }

        /// <inheritdoc />
        public async Task<bool> Registration(RegistrationModel model)
        {
            var settings = new HttpSettings(_httpService.BuildUrl(Url, "registration")).AddToaster("Registration");

            var body = new HttpBody<RegistrationModel>(model);

            return await _httpService.Post(settings, body).Execute();
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