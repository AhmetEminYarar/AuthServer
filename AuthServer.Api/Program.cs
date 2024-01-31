using AuthServer.Data.Extensions;
using AuthServer.DTO.Extensions;
using AutServer.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.LoadDto();
builder.Services.LoadService();
builder.Services.LoadData(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.MapControllers();

app.Run();
