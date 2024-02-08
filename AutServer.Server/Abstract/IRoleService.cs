using AuthServer.Data.Entity;

namespace AutServer.Server.Abstract
{
    public  interface IRoleService
    {
        Task<Role> AddAsync(Role entity);
        Task<List<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(long id);
        Task UpdateAsync(Role entity);
    }
}
