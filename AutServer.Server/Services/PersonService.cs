using AuthServer.Data.Entity;
using AuthServer.Data.Repository;
using AutServer.Server.Abstract;
using Microsoft.AspNetCore.Http;

namespace AutServer.Server.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<long> Add(Person entity, IFormFile formFile)
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

                entity.PersonImageURL = fileName;
            }
            await _repository.Add(entity);
            return entity.Id;
        }

        public async Task<long> Update(Person entity, IFormFile formFile)
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

                entity.PersonImageURL = fileName;
            }
            await _repository.Update(entity);
            return entity.Id;
        }

        public async Task<long> Delete(Person entity)
        {
            if (entity == null)
            {
                throw new Exception("Hata Update !");
            }
            await _repository.Delete(entity);
            return entity.Id;
        }

        public async Task<List<Person>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Person> GetById(long Id)
        {
            var response = await _repository.GetById(Id);
            if (response == null)
                throw new Exception("Hata ById !");
            else
                return response;
        }


    }
}
