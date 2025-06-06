using HealthChecks.System;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HealthChecks com limites configuráveis
builder.Services.AddHealthChecks();
    // .AddCheck("cpu", new CpuHealthCheck(0.90))
    // .AddCheck("memory", new MemoryHealthCheck(0.85))
    // .AddCheck("disk", new DiskStorageHealthCheck("C:\\", 0.90))
    // .AddCheck("uptime", new SystemUptimeHealthCheck(TimeSpan.FromMinutes(10)));

// HealthChecks UI
    builder.Services.AddHealthChecksUI(options =>
        {
            options.AddHealthCheckEndpoint("self", "/health");
        })
        .AddInMemoryStorage();// Ou use .AddSqlServerStorage(connString) se quiser persistir

var app = builder.Build();

// Swagger sempre disponível
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CheckHealthNet API V1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Endpoint de Health Check
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

// UI do HealthChecks (Dashboard)
app.MapHealthChecksUI(options =>
{
    options.UIPath = "/hc-ui"; // Acessar em /hc-ui
    options.ApiPath = "/hc-ui-api";
});

app.Run();