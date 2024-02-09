using AuthServer.Api.Middlewares;
using AuthServer.Data.Extensions;
using AuthServer.DTO.Extensions;
using AutServer.Server.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    x.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.LoadDto();
builder.Services.LoadService(builder.Configuration);
builder.Services.LoadData(builder.Configuration);

builder.Services.AddTransient<GlobalExMiddleware>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalExMiddleware>();

app.MapControllers();

app.Run();
