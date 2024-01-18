using AutServer.Server.Abstract;
using AutServer.Server.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AutServer.Server.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection LoadService (this IServiceCollection services) 
        {
            services.AddScoped<IPersonService,PersonService>();
            return services;
        }
    }
}
