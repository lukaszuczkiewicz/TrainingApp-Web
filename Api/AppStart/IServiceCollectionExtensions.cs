using Application.IdentityAndAccess.Services;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Notification.Abstractions;
using Persistence.Abstractions;
using Serilog;
using System;
using System.Linq;
using System.Text;

namespace TraingAppBackEnd.AppStart
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCustomCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedOrigins = configuration
                .GetSection("AllowedCorsOrigins")
                .GetChildren()
                .ToArray()
                .Select(p => p.Value)
                .ToArray();

            services.AddCors(options =>
            {
                options.AddPolicy("Default policy", builder =>
                {
                    builder
                    .WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .Build();
                });
            });
        }

        public static void AddJWTTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var issuer = configuration["JwtOptions:Issuer"];
            var audience = configuration["JwtOptions:Audience"];
            var securityKey = configuration["JwtOptions:SecurityKey"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
                    };
                });
        }

        public static void AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            services.Configure<SendGridConfiguration>(configuration.GetSection("SendGridConfiguration"));
            services.Configure<DailyEmailConfiguration>(configuration.GetSection("DailyEmailConfiguration"));
        }

        public static void AddHangfire(this IServiceCollection services, IConfiguration config)
        {
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSerilogLogProvider()
                .UseSqlServerStorage(config.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions()
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                })
            );

            services.AddHangfireServer();

            JobStorage.Current = new SqlServerStorage(config.GetConnectionString("HangfireConnection"));
            //RecurringJob.AddOrUpdate<EmailBackgroudService>(x => x.SendDailyEmails(), Cron.Minutely);
        }
    }
}
