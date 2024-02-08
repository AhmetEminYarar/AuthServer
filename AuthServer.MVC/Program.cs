using AuthServer.Data.Extensions;
using AuthServer.DTO.Extensions;

using AutServer.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddHttpClient<ApiService>(x => {
//    x.BaseAddress = new Uri("htp://localhost:5141");
//});
builder.Services.AddControllersWithViews();
builder.Services.LoadData(builder.Configuration);
builder.Services.LoadDto();
builder.Services.LoadService(builder.Configuration);

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
    pattern: "{controller=Home}/{action=Index}/{id?}");///////asdviþjkashovuhabnvpþcýkhqavopqac Controller düzelt Home olcak 

app.Run();
