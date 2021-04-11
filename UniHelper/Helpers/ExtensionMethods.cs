using System;
using System.Collections.Specialized;
using System.Web;
using Microsoft.AspNetCore.Components;

namespace UniHelper.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Get Query Strings from Uri
        /// </summary>
        /// <param name="navigationManager">navigation Manager</param>
        /// <returns>Name value collection</returns>
        public static NameValueCollection QueryString(this NavigationManager navigationManager)
        {
            return HttpUtility.ParseQueryString(new Uri(navigationManager.Uri).Query);
        }

        /// <summary>
        /// Get Query string by key
        /// </summary>
        /// <param name="navigationManager">Navigation Manager</param>
        /// <param name="key">Key word</param>
        /// <returns>Value with the given key</returns>
        public static string QueryString(this NavigationManager navigationManager, string key)
        {
            return navigationManager.QueryString()[key];
        }
    }
}