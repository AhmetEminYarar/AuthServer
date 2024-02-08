using AuthServer.DTO.Request.Authentication;
using AuthServer.DTO.Request.People;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.DTO.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection LoadDto (this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<PersonAddRequest>();
            services.AddValidatorsFromAssemblyContaining<PersonUpdateRequest>();
            services.AddValidatorsFromAssemblyContaining<AuthenticationRequest>();
            return services;


        }
    }
}
