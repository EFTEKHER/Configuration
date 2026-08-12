using Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("weatherapi"));
builder.Services.Configure<MyKeyOptions>(builder.Configuration.GetSection("mykey"));
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MYconfig.json", optional: true, reloadOnChange: true);

});
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
// read environment file;

//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/config", async context =>
//    {
//        await context.Response.WriteAsync($"{app.Configuration["MyKey"]} \n");

//        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") + "\n");
//        //suppose hard coded
//        await context.Response.WriteAsync(app.Configuration.GetValue<int>("x",10)+"\n");

//    });
//});
app.MapControllers();



app.Run();
