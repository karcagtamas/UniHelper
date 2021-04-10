using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using UniHelper.Services;
using UniHelper.Shared.Models;

namespace UniHelper
{
    /// <summary>
    /// Client Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Program
        /// </summary>
        /// <param name="args">Program Args</param>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOptions();
            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
            builder.Services.AddScoped<IHelperService, HelperService>();
            builder.Services.AddScoped<IPeriodService, PeriodService>();
            builder.Services.AddScoped<ISubjectService, SubjectService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IGlobalNoteService, GlobalNoteService>();
            builder.Services.AddScoped<IGlobalTaskService, GlobalTaskService>();
            builder.Services.AddScoped<IPeriodNoteService, PeriodNoteService>();
            builder.Services.AddScoped<IPeriodTaskService, PeriodTaskService>();
            builder.Services.AddScoped<ISubjectNoteService, SubjectNoteService>();
            builder.Services.AddScoped<ISubjectTaskService, SubjectTaskService>();
            builder.Services.AddScoped<ICalendarService, CalendarService>();
            builder.Services.AddScoped<ILessonHourService, LessonHourService>();
            builder.Services.AddScoped<IToasterService, ToasterService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
            builder.Services.AddHttpService(config =>
            {
                config.IsTokenBearer = true;
                config.UnauthorizedPath = "/logout";
                config.TokenName = "token";
            });
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            var host = builder.Build();
            
            var localStorageService = host.Services.GetRequiredService<ILocalStorageService>();
            var storeService = new StoreService(localStorageService);
            await storeService.Init();
            builder.Services.AddSingleton<IStoreService>(storeService);

            ApplicationSettings.BaseUrl = builder.Configuration.GetSection("Api").Value;
            ApplicationSettings.BaseApiUrl = ApplicationSettings.BaseUrl += "/api";

            await builder.Build().RunAsync();
        }
    }
}