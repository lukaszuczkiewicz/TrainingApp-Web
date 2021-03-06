﻿using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using Api.AppStart;
using App.Metrics.AspNetCore;

namespace TraingAppBackEnd
{
    public class Program
    {
        public static IConfiguration Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();

        public static void Main(string[] args)
        {
            SeriloggerConfiguration.InitLoger(Configuration);

            try
            {
                Log.Information("Starting web host...");
                CreateWebHostBuilder(args)
                    .Build()
                    .Run();
            }
            catch
            {
                Log.Error("Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseMetrics()
            .ConfigureServices(s => s.AddAutofac())
            .UseStartup<Startup>()
            .UseSerilog();      
    }
}
