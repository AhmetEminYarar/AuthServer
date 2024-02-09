using AuthServer.Data.Entity;
using AuthServer.Data.Repository;
using AutServer.Server.Abstract;
using Microsoft.AspNetCore.Http;

namespace AutServer.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> Add(User entity, IFormFile formFile)
        {
            if (formFile != null && formFile.Length > 0)
            {
                var uploadFolderPath = Path.Combine("wwwroot", "Image");

                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                var fileName = Path.GetRandomFileName();
                var filePath = Path.Combine(uploadFolderPath, fileName);

                using (var stream = File.Create(filePath))
                {
                    await formFile.CopyToAsync(stream);
                }

                entity.UserImageURL = fileName;
            }
            var user = await GetByTCKN(entity.TCKN);
            if (user != null)
            {
                throw new Exception("Hata TCKN Mevcut");
            }
            entity.UserNameToLower = entity.UserName.ToLower();
            entity.EmailToLower = entity.Email.ToLower();
            entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(entity.PasswordHash);
            entity.RoleId = 1;
            await _repository.Add(entity);
            return entity;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<User> GetByTCKN(string? TCKN)
        {
            return await _repository.SingleOrDefaultAsync(x => x.TCKN == TCKN);
        }

        public async Task<User> Update(User entity, IFormFile formFile)
        {
            if (formFile != null && formFile.Length > 0)
            {
                var uploadFolderPath = Path.Combine("wwwroot", "Image");

                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                var fileName = Path.GetRandomFileName();
                var filePath = Path.Combine(uploadFolderPath, fileName);

                using (var stream = File.Create(filePath))
                {
                    await formFile.CopyToAsync(stream);
                }

                entity.UserImageURL = fileName;
            }

            var user = await GetByTCKN(entity.TCKN);
            if (user != null)
            {
                throw new Exception("Hata User Mevcut");
            }
            entity.UserNameToLower = entity.UserName.ToLower();
            entity.EmailToLower = entity.Email.ToLower();
            entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(entity.PasswordHash);
            await _repository.Update(entity);
            return entity;
        }

        public async Task<IEnumerable<User>> WhereAsync(long UserId)
        {
         return await _repository.WhereAsync(x=>x.Id== UserId);
        }
    }
}
