using AuthServer.Data.Extensions;
using AuthServer.DTO.Extensions;
using AuthServer.MVC.ApiServices;
using AutServer.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.LoadData(builder.Configuration);
builder.Services.LoadDto();
builder.Services.LoadService();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
