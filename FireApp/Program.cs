using FireApp.Services;
using Hangfire;
using Hangfire.Storage.SQLite;
using Hangfire.Dashboard.BasicAuthorization;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(config => config
                                        .UseSimpleAssemblyNameTypeSerializer()
                                        .UseRecommendedSerializerSettings()
                                        .UseSQLiteStorage(builder.Configuration.GetConnectionString("DBConn")));

builder.Services.AddHangfireServer();

builder.Services.AddTransient<IServiceManagement, ServiceManagement>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard();
/*app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    DashboardTitle = "FireBoard",
    Authorization = new[]
    {
        new HangfireCustomBasicAuthenticationFilter
        {
            User = "admin",
            Pass = "admin"
        }
    }
});*/


app.MapHangfireDashboard();


//RecurringJob.AddOrUpdate<IServiceManagement>(x => x.sendEmail(), "0 * * ? * *"); //Every min
//RecurringJob.AddOrUpdate<IServiceManagement>(x => x.SyncData(), "0 */2 * ? * *"); //Every 2 min
RecurringJob.AddOrUpdate<IServiceManagement>(x => x.UpdateDatabase(), "0 * * ? * *"); //Every min
//RecurringJob.AddOrUpdate<IServiceManagement>(x => x.GenerateMerchendise(), "0 */4 * ? * *"); //Every 4 min

app.Run();
