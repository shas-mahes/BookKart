using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using System.Text.Json.Serialization;
using BookKart.Core.Infrastructure;
using BookKart.Core.Infrastructure.DataContext;
using BookKart.API;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add dependency for DbContext and Repositories
builder.Services.ConfigurePersistence(builder.Configuration);

// Add dependency for nexus services.
builder.Services.ConfigureServices(builder.Configuration);

//Add Nlogger
builder.Logging.AddNLogger(builder.Host);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = new CustomJsonSerializationPolicy();
    });

builder.Services.AddSwaggerGen(
  c => {
      c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
      c.IgnoreObsoleteActions();
      c.IgnoreObsoleteProperties();
      c.CustomSchemaIds(type => type.FullName);
  });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

var app = builder.Build();

// Database auto migration 
using (var scope = app.Services.CreateScope())
{
    logger.Info("Started Database migration...");
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.Migrate();
    logger.Info("Database migration is completed successfully...");
}

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
