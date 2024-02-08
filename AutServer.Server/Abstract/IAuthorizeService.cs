using AuthServer.Data.Entity;
using AuthServer.DTO.Request.Authentication;

namespace AutServer.Server.Abstract
{
    public interface IAuthorizeService
    {
        Task<string> UserValidator(AuthenticationRequest entity);    
        string CreateToken(User entity);


    }
}
