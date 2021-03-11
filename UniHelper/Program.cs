using System;
using System.Net.Http;
using System.Threading.Tasks;
using Karcags.Blazor.Common.Http;
using Karcags.Blazor.Common.Models;
using Karcags.Blazor.Common.Services;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using UniHelper.Services;

namespace UniHelper
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOptions();
            builder.Services.AddScoped(
                sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMatBlazor();
            builder.Services.AddScoped<IHelperService, HelperService>();
            builder.Services.AddScoped<IHttpService, HttpService>();
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
            builder.Services.AddMudServices();

            ApplicationSettings.BaseUrl = builder.Configuration.GetSection("Api").Value;
            ApplicationSettings.BaseApiUrl = ApplicationSettings.BaseUrl += "/api";

            builder.Services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });

            await builder.Build().RunAsync();
        }
    }
}