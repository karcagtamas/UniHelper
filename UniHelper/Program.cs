using Blazored.LocalStorage;
using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;
using KarcagS.Blazor.Common.Services;
using KarcagS.Blazor.Common.Store;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using UniHelper;
using UniHelper.Services;
using UniHelper.Shared.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
// builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationStateProvider>();

builder.Services.AddScoped(
                sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpService(config =>
{
    config.IsTokenBearer = true;
    config.UnauthorizedPath = "/logout";
    config.AccessTokenName = "access-token";
    config.IsTokenRefresher = true;
    config.RefreshTokenName = "refresh-token";
    config.RefreshUri = builder.Configuration.GetSection("RefreshUri").Value;
    config.RefreshTokenPlaceholder = ":refreshToken";
    config.ClientIdName = "client-id";
    config.ClientIdPlaceholder = ":clientId";
});
builder.Services.AddScoped<IHelperService, HelperService>();
builder.Services.AddScoped<IPeriodService, PeriodService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IGlobalTaskService, GlobalTaskService>();
builder.Services.AddScoped<IPeriodTaskService, PeriodTaskService>();
builder.Services.AddScoped<ISubjectTaskService, SubjectTaskService>();
builder.Services.AddScoped<ICalendarService, CalendarService>();
builder.Services.AddScoped<ILessonHourService, LessonHourService>();
builder.Services.AddScoped<IToasterService, ToasterService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IStatService, StatService>();

builder.Services.AddStoreService(async (storeService, localStorage) =>
{
    var user = await localStorage.GetItemAsync<StorageUser>("user");

    if (user != null)
    {
        storeService.Add("user", user);
    }
});
builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
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

ApplicationSettings.BaseUrl = builder.Configuration.GetSection("SecureApi").Value;
ApplicationSettings.BaseApiUrl = ApplicationSettings.BaseUrl += "/api";

await builder.Build().RunAsync();