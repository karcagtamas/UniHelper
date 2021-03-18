using System.Threading.Tasks;
using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <inheritdoc />
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpService _httpService;

        private string Url { get; set; } = ApplicationSettings.BaseApiUrl + "/auth";

        /// <summary>
        /// Init Authentication Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public AuthenticationService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<string> Login(LoginModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("login", -1);

            var settings = new HttpSettings(Url, null, pathParams);

            var body = new HttpBody<LoginModel>(model);

            return await _httpService.CreateString(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> Registration(RegistrationModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add("registration", -1);

            var settings = new HttpSettings(Url, null, pathParams);

            var body = new HttpBody<RegistrationModel>(model);

            return await _httpService.Create(settings, body);
        }
    }
}