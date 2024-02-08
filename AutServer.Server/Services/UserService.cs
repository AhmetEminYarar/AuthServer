using AuthServer.Data.Entity;
using AuthServer.Data.Repository;
using AutServer.Server.Abstract;

namespace AutServer.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<long> Add(User entity)
        {
            var user = await GetByUserName(entity.UserName);
            if (user != null)
            {
                throw new Exception("Hata User Mevcut");
            }
            entity.UserNameToLower = entity.UserName.ToLower();
            entity.EmailToLower = entity.Email.ToLower();
            entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(entity.PasswordHash);
            entity.RoleId = 1;
            await _repository.Add(entity);
            return entity.Id;
        }

        public async Task<List<User>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<User> GetByUserName(string UserName)
        {
            return await _repository.SingleOrDefaultAsync(x => x.UserNameToLower == UserName.ToLower());
        }

        public async Task<long> Update(User entity)
        {

            var user = await GetByUserName(entity.UserName);
            if (user != null)
            {
                throw new Exception("Hata User Mevcut");
            }
            entity.UserNameToLower = entity.UserName.ToLower();
            entity.EmailToLower = entity.Email.ToLower();
            entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(entity.PasswordHash);
            await _repository.Update(entity);
            return entity.Id;
        }
    }
}
