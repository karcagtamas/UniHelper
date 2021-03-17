using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace UniHelper.Backend
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">Program args</param>
        public static void Main(string[] args)
        {
            CreateWebHost(args).Run();
        }

        /// <summary>
        /// Create Web Host
        /// </summary>
        /// <param name="args">Program args</param>
        /// <returns>Web Host</returns>
        public static IWebHost CreateWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                //.UseContentRoot(Directory.GetCurrentDirectory())
                .UseContentRoot(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}