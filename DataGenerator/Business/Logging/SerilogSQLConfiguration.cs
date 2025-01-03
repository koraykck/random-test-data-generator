using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logging
{
    public static class SerilogSQLConfiguration
    {
        public static ILogger CreateLogger(this ILogger log, string appName, string connectionString)
        {
            var columnOpts = new ColumnOptions();
            columnOpts.Store.Remove(StandardColumn.Properties);
            columnOpts.Store.Remove(StandardColumn.MessageTemplate);
            columnOpts.AdditionalColumns = new Collection<SqlColumn>
            {
                new SqlColumn {ColumnName = "UserName", PropertyName = "UserName", DataType = SqlDbType.NVarChar, DataLength = 100},
                new SqlColumn {ColumnName = "AppName", DataType = SqlDbType.NVarChar, DataLength = 100, AllowNull = false},
                new SqlColumn {ColumnName = "Controller", PropertyName = "Controller", DataType = SqlDbType.NVarChar, DataLength = 1000},
                new SqlColumn {ColumnName = "Action", PropertyName = "Action", DataType = SqlDbType.NVarChar, DataLength = 1000},
                new SqlColumn {ColumnName = "RequestMethod", PropertyName = "RequestMethod", DataType = SqlDbType.NVarChar, DataLength = 10},
                new SqlColumn {ColumnName = "RequestPath", PropertyName = "RequestPath", DataType = SqlDbType.NVarChar, DataLength = 1000},
                new SqlColumn {ColumnName = "RequestQueryString", PropertyName = "RequestQueryString", DataType = SqlDbType.NVarChar, DataLength = -1},
                new SqlColumn {ColumnName = "RequestForm", PropertyName = "RequestForm", DataType = SqlDbType.NVarChar, DataLength = -1},
                new SqlColumn {ColumnName = "RequestBody", PropertyName = "RequestBody", DataType = SqlDbType.NVarChar, DataLength = -1},
                new SqlColumn {ColumnName = "ResponseBody", PropertyName = "ResponseBody", DataType = SqlDbType.NVarChar, DataLength = -1},
                new SqlColumn {ColumnName = "CommandText", PropertyName = "commandText", DataType = SqlDbType.NVarChar, DataLength = -1},
                new SqlColumn {ColumnName = "HTTPStatusCode", PropertyName = "HTTPStatusCode", DataType = SqlDbType.Int},
                new SqlColumn {ColumnName = "Duration", PropertyName = "Duration", DataType = SqlDbType.Float },
                new SqlColumn {ColumnName = "IPAddress", PropertyName = "IPAddress", DataType = SqlDbType.NVarChar, DataLength = 100},

            };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
                .Enrich.WithProperty("AppName", appName)
                .Enrich.FromLogContext()
                .WriteTo.Logger(l => l
                //.Filter.ByIncludingOnly(e => e.Properties.ContainsKey("Control"))
                    .WriteTo.MSSqlServer(
                        connectionString: connectionString,
                        sinkOptions: new MSSqlServerSinkOptions { SchemaName = "LogModel", TableName = "RequestLog", AutoCreateSqlTable = true, BatchPeriod = TimeSpan.FromMilliseconds(20), BatchPostingLimit = 100 },
                        columnOptions: columnOpts
                    )
                    )
                .CreateLogger();

            return log;

        }
    }
}
