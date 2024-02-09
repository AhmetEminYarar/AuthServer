using AuthServer.Data.Entity;
using Microsoft.AspNetCore.Http;

namespace AutServer.Server.Abstract
{
    public interface IUserService
    {
        Task<User> Add(User entity, IFormFile formFile);        
        Task<User> Update(User entity, IFormFile formFile);
        Task<User> GetByTCKN(string TCKN);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> WhereAsync(long UserId);
        //Task<User> GetById(long Id);
        //Task<User> SingleOrDefaultAsync(Expression<Func<User, bool>> predicate);
        //Task<IEnumerable<User>> IncludeAsync(params string[] properties);




    }
}

