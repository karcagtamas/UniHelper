using System.Text;
using AutoMapper;
using Karcags.Common.Middlewares;
using Karcags.Common.Tools.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using UniHelper.Backend.Mappers;
using UniHelper.Backend.Services;
using UniHelper.Shared;

namespace UniHelper.Backend
{
    /// <summary>
    /// Startup of Project
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup method
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// App configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configure Services
        /// </summary>
        /// <param name="services">Service collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins(Configuration.GetValue("SecureClientUrl", "https://localhost:5001"), Configuration.GetValue("ClientUrl", "http://localhost:5000"));
                });
            });

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<DatabaseContext>(options =>
                options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new PeriodMapper());
                x.AddProfile(new SubjectMapper());
                x.AddProfile(new CourseMapper());
                x.AddProfile(new NoteMapper());
                x.AddProfile(new TaskMapper());
                x.AddProfile(new LessonHourMapper());
                x.AddProfile(new UserMapper());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton<ExceptionHandler>();

            services.AddLogging();

            services.AddScoped<IUtilsService, UtilsService<DatabaseContext>>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<IPeriodService, PeriodService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IGlobalNoteService, GlobalNoteService>();
            services.AddScoped<IPeriodNoteService, PeriodNoteService>();
            services.AddScoped<ISubjectNoteService, SubjectNoteService>();
            services.AddScoped<IGlobalTaskService, GlobalTaskService>();
            services.AddScoped<IPeriodTaskService, PeriodTaskService>();
            services.AddScoped<ISubjectTaskService, SubjectTaskService>();
            services.AddScoped<ICalendarService, CalendarService>();
            services.AddScoped<ILessonHourService, LessonHourService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITaskService, TaskService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new TimeSpanConverter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniHelper.Backend", Version = "v1" });
            });
        }
        
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <param name="env">Web host environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMyExceptionHandler();
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniHelper.Backend v1"));
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}