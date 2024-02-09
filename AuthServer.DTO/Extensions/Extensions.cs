using AuthServer.DTO.Request.Authentication;
using AuthServer.DTO.Request.Users;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthServer.DTO.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection LoadDto (this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssemblyContaining<AuthenticationLoginRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<UserAddRequestValidator>();            
            services.AddValidatorsFromAssemblyContaining<UserUpdateRequestValidator>();            
            return services;


        }
    }
}
