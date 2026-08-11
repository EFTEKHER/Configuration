var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
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
