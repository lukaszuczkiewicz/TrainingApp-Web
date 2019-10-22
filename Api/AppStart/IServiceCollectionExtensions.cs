using Application.IdentityAndAccess.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.Abstractions;
using Serilog;
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
        }
    }
}
