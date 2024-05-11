using Serilog;
using Job.Candidate.Hub.API;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

Log.Information("JobCandidateHub API starting");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
     .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
     .ReadFrom.Configuration(context.Configuration));

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

app.UseSerilogRequestLogging();

app.Run();

public partial class Program { }