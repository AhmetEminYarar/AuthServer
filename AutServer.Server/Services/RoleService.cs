using AuthServer.Data.Entity;
using AuthServer.Data.Repository;
using AutServer.Server.Abstract;

namespace AutServer.Server.Services
{
    public class RoleService:IRoleService
    {
        private readonly IRepository<Role> _repository;

        public RoleService(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task<Role> AddAsync(Role entity)
        {
            await _repository.Add(entity);
            return entity;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Role> GetByIdAsync(long id)
        {
            return await _repository.GetById(id);

        }

        public async Task UpdateAsync(Role entity)
        {
            await _repository.Update(entity);

        }
       
    }
}
