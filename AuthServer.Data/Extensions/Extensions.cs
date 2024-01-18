using AuthServer.Data.Context;
using AuthServer.Data.Repository;
using AuthServer.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Data.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection Load(IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddDbContext<AppDbContext>(x=>x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
