using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System.IO;

namespace TraingAppBackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitLogger();
            RunApplication(args);
        }

        public static void RunApplication(string[] args)
        {
            try
            {
                Log.Information("Starting web host");
                CreateWebHostBuilder(args)
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                Log.Fatal("Host went down, EXCEPTION: ", ex);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static void InitLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Micosoft", LogEventLevel.Information)
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "log"), rollingInterval: RollingInterval.Hour)
                .CreateLogger();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(s => s.AddAutofac())
                .UseSerilog()
                .UseStartup<Startup>();              
    }
}
