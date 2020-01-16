using Api.ViewModels.NewFolder;
using Application.Coach.Commands;
using Application.IdentityAndAccess.Services;
using Autofac;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Serilog;
using System;
using TraingAppBackEnd.AppStart;
using TraingAppBackEnd.CompositionRoot;
using TraingAppBackEnd.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Hangfire.AspNetCore;
using Hangfire.Common;
using Notification.BackgroudServices;
using Hangfire;

namespace TraingAppBackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModules();        
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(options =>
                options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: sqlOptions => 
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 20,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    })
                    .UseLazyLoadingProxies());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(o => 
                    {
                        o.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>();
                        o.RegisterValidatorsFromAssemblyContaining<CreateCoachCommandValidator>();
                        o.RegisterValidatorsFromAssemblyContaining<NewTraningReqestValidator>();
                        o.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    }
                );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "TraninigApp", Version = "v1" });
            });

            services.AddHttpContextAccessor();
            services.AddAppSettings(Configuration);
            services.AddJWTTokenAuthentication(Configuration);
            services.AddCustomCorsPolicy(Configuration);
            services.AddHangfire(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IRecurringJobManager recurringJobManager, IBackgroundJobClient backgroundJobs, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseSerilogRequestLogging();
            //app.UseMiddleware<ErrorHandligMiddleware>();

            app.UseHangfireDashboard();

            var job = Job.FromExpression<EmailBackgroudService>(m => m.SendDailyEmails());
            recurringJobManager.AddOrUpdate(
                "EmailService", job, Cron.Weekly(DayOfWeek.Monday, 10), new RecurringJobOptions());

            app.UseAuthentication();
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseHttpsRedirection();         
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
            });
        }
    }
}
