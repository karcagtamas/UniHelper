using AutoMapper;
using KarcagS.Common.Tools.HttpInterceptor;
using KarcagS.Common.Tools.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;
using UniHelper.Backend;
using UniHelper.Backend.Mappers;
using UniHelper.Backend.Services;
using UniHelper.Backend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Config
//builder.Services.Configure<JWTConfiguration>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", b =>
    {
        b.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins(builder.Configuration.GetValue("SecureClientUrl", "https://localhost:5001"), builder.Configuration.GetValue("ClientUrl", "http://localhost:5000"));
    });
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<DatabaseContext>(options =>
    options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var mapperConfig = new MapperConfiguration(x =>
{
    x.AddProfile(new PeriodMapper());
    x.AddProfile(new SubjectMapper());
    x.AddProfile(new CourseMapper());
    x.AddProfile(new TaskMapper());
    x.AddProfile(new LessonHourMapper());
    x.AddProfile(new UserMapper());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddLogging();

builder.Services.AddScoped<IUtilsService, UtilsService<DatabaseContext>>();
builder.Services.AddScoped<ILoggerService, LoggerService>();
builder.Services.AddScoped<IPeriodService, PeriodService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IGlobalTaskService, GlobalTaskService>();
builder.Services.AddScoped<IPeriodTaskService, PeriodTaskService>();
builder.Services.AddScoped<ISubjectTaskService, SubjectTaskService>();
builder.Services.AddScoped<ICalendarService, CalendarService>();
builder.Services.AddScoped<ILessonHourService, LessonHourService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IStatService, StatService>();
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddModelValidatedControllers();//.AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new Time));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(conf =>
{
    conf.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT containing userid claim",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    });

    conf.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                },
                UnresolvedReference = true
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpInterceptor();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();