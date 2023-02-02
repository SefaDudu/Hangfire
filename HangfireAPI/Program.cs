using Core.Service;
using DataAccess.Context;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddTransient<ApiDbContext>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = "host=localhost; port=5432; database=hangfire; username=postgres; password=postgrespw";

builder.Services.AddHangfire(config =>
{
   
    var option = new PostgreSqlStorageOptions()
    {
        PrepareSchemaIfNecessary= true,
        QueuePollInterval=TimeSpan.FromSeconds(5),
    };
    
    config.UsePostgreSqlStorage(connection,option).WithJobExpirationTimeout(TimeSpan.FromHours(5));
}
);
builder.Services.AddHangfireServer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
  
});

//builder.Services.AddHangFire

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();


app.UseHangfireDashboard();
app.UseHangfireServer(); 
app.UseAuthorization();
app.MapControllers();
Core.BackgroundJob.RecurringJobs.RecurringJobs.FileUpload();

app.Run();
