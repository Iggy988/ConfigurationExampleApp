using ConfigurationExample;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//supply an object of WeatherApiOptions (with 'weatherapi' section) as a service za DI
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("weatherapi"));

//Load MyOwnConfig.json
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyOwnConfig.json", true, true);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/config", async context =>
//    {
//        //za citanje value from MyKey(appsettings.json)
//        await context.Response.WriteAsync(app.Configuration["MyKey"]+"\n");
//        //drugi nacin koristeci GetValue
//        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") + "\n");
//        // ako nema odredjenog key unosimo defauult value
//        await context.Response.WriteAsync(app.Configuration.GetValue<int>("x",10 )+"\n");
//    });
//});
app.MapControllers();

app.Run();
