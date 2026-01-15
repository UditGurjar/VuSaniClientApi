using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Text.Json.Serialization;
using VuSaniClientApi.Application;
using VuSaniClientApi.Authentication;
using VuSaniClientApi.Infrastructure;
using VuSaniClientApi.Infrastructure.DBContext;

var builder = WebApplication.CreateBuilder(args);
// Serilog configuration
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.File("ErrorLogs/log.txt", LogEventLevel.Verbose, rollingInterval: RollingInterval.Day,
        fileSizeLimitBytes: 50 * 1024 * 1024,
        rollOnFileSizeLimit: true,
        retainedFileCountLimit: null)
    .CreateLogger();
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VsaniDbCon")));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.RegisterJwtAuthentication(builder.Configuration);

// ✅ Configure CORS for Angular (default port 4200)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            //policy.WithOrigins("http://localhost:5173") // Angular default port
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
            //.AllowCredentials();
        });
});
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// ✅ Auto apply EF Core migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        await db.Database.MigrateAsync();
        Log.Information("Database migration completed successfully");
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Database migration failed");
        throw;
    }
}
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");   // ✅ ADD THIS LINE

app.UseAuthorization();

app.MapControllers();

app.Run();
