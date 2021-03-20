using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using UniHelper.Services;

namespace UniHelper.Helpers
{
    /// <summary>
    /// App Route view for auth
    /// </summary>
    public class AppRouteView : RouteView
    {
        /// <summary>
        /// Navigation Manager
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        /// <summary>
        /// Authentication Service
        /// </summary>
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        /// <summary>
        /// Render Page
        /// </summary>
        /// <param name="builder">Tree builder</param>
        protected override void Render(RenderTreeBuilder builder)
        {
            var authorize = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute)) != null;
            if (authorize && !AuthenticationService.IsLoggedIn())
            {
                var returnUrl = WebUtility.UrlEncode(new Uri(NavigationManager.Uri).PathAndQuery);
                NavigationManager.NavigateTo($"login?returnUrl={returnUrl}");
            }
            else
            {
                base.Render(builder);
            }
        }
    }
}