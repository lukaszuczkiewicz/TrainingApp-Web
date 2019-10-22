using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.AppStart
{
    internal static class SeriloggerConfiguration
    {
        public static void InitLoger(IConfiguration configuration)
        {
            var logDB = configuration.GetConnectionString("DefaultConnection");
            var schemaName = "Serilog";
            var logTable = "Logs";
            var options = new ColumnOptions();
            options.Store.Add(StandardColumn.LogEvent);
            options.LogEvent.DataLength = 2048;
            options.PrimaryKey = options.TimeStamp;
            options.TimeStamp.NonClusteredIndex = true;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.MSSqlServer(
                connectionString: logDB,
                schemaName: schemaName,
                tableName: logTable,
                columnOptions: options,
                autoCreateSqlTable: true)
                //.WriteTo.File(new JsonFormatter(), "logs.txt") //diable for development
                .CreateLogger();
        }
    }
}
