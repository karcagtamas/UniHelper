using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UniHelper
{
    public class UniAuthStateProvider /* : AuthenticationStateProvider*/
    {
        /*
        private readonly ITokenService tokenService;

        public UniAuthStateProvider(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        public void MarkUserAsAuthenticated()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await tokenService.RefreshStore();
            var token = await tokenService.GetUser();

            if (token is null || string.IsNullOrEmpty(token.AccessToken))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var accessToken = token.AccessToken;

            return new AuthenticationState(
                new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(accessToken), "jwt")));
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var jwtToken = new JwtSecurityToken(jwt);

            return jwtToken.Claims;
        }
        */
    }
}
