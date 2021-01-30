using AutoMapper;
using Karcags.Common.Middlewares;
using Karcags.Common.Tools.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UniHelper.Backend.Mappers;
using UniHelper.Backend.Services;
using UniHelper.Shared;

namespace UniHelper.Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("TestPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("https://localhost:5001", "http://localhost:5000");
                });
                
                opt.AddPolicy("ReleasePolicy", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("https://localhost:5001", "http://localhost:5000");
                });
            });

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<DatabaseContext>(options =>
                options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new PeriodMapper());
                x.AddProfile(new SubjectMapper());
                x.AddProfile(new CourseMapper());
                x.AddProfile(new NoteMapper());
                x.AddProfile(new TaskMapper());
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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new TimeSpanConverter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "UniHelper.Backend", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMyExceptionHandler();
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniHelper.Backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(env.IsDevelopment() ? "TestPolicy" : "ReleasePolicy");

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}