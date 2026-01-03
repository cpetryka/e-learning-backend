using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

public class SlowQueryInterceptor : DbCommandInterceptor
{
    private const int SlowQueryThreshold = 50; // ms
    private readonly ILogger<SlowQueryInterceptor> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SlowQueryInterceptor(
        ILogger<SlowQueryInterceptor> logger,
        IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    private string GetEndpoint()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null) return "Unknown";

        var path = httpContext.Request.Path.Value ?? "";
        var method = httpContext.Request.Method;
        return $"{method} {path}";
    }

    private string FormatSqlWithParameters(DbCommand command)
    {
        var sql = command.CommandText;
        
        // Dodaj parametry do SQL
        foreach (DbParameter param in command.Parameters)
        {
            var paramName = param.ParameterName;
            var paramValue = param.Value?.ToString() ?? "NULL";
            
            // Ogranicz długość wartości parametru dla czytelności
            if (paramValue.Length > 100)
            {
                paramValue = paramValue.Substring(0, 100) + "...";
            }
            
            sql = sql.Replace(paramName, $"'{paramValue}'");
        }
        
        return sql;
    }

    public override ValueTask<DbDataReader> ReaderExecutedAsync(
        DbCommand command,
        CommandExecutedEventData eventData,
        DbDataReader result,
        CancellationToken cancellationToken = default)
    {
        LogQuery(command, eventData);
        return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
    }

    public override DbDataReader ReaderExecuted(
        DbCommand command,
        CommandExecutedEventData eventData,
        DbDataReader result)
    {
        LogQuery(command, eventData);
        return base.ReaderExecuted(command, eventData, result);
    }

    private void LogQuery(DbCommand command, CommandExecutedEventData eventData)
    {
        var duration = eventData.Duration.TotalMilliseconds;
        var endpoint = GetEndpoint();
        var sql = FormatSqlWithParameters(command);
        
        // Loguj wszystkie zapytania jako Information, wolne jako Warning
        if (duration > SlowQueryThreshold)
        {
            _logger.LogWarning(
                "SLOW SQL QUERY detected | Endpoint: {Endpoint} | Duration: {Duration}ms | SQL: {Sql}",
                endpoint,
                duration,
                sql);
        }
        else
        {
            _logger.LogInformation(
                "SQL QUERY | Endpoint: {Endpoint} | Duration: {Duration}ms | SQL: {Sql}",
                endpoint,
                duration,
                sql);
        }
    }
}