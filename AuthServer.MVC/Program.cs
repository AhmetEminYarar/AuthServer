using AuthServer.Api.Middlewares;
using AuthServer.Data.Extensions;
using AuthServer.DTO.Extensions;
using AuthServer.MVC.MiddleWare;
using AutServer.Server.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddHttpClient<ApiService>(x => {
//    x.BaseAddress = new Uri("htp://localhost:5141");
//});
builder.Services.AddControllersWithViews();

builder.Services.LoadData(builder.Configuration);
builder.Services.LoadDto();
builder.Services.LoadService(builder.Configuration);
builder.Services.AddTransient<MVCMiddleWare>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(opt =>
            {
                opt.LoginPath = "/Login/Login";
            });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthorization();

app.UseMiddleware<MVCMiddleWare>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
