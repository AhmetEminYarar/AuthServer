using AuthServer.Data.Entity;
using AuthServer.Data.Repository;
using AutServer.Server.Abstract;
using Microsoft.AspNetCore.Http;
using System;

namespace AutServer.Server.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<int> Add(Person entity, IFormFile formFile)
        {
            if (formFile != null)
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine("wwwroot", "Image", Path.GetRandomFileName());
                    using (var stream = File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    entity.PersonImageURL = filePath;
                }
            await _repository.Add(entity);
            return entity.Id;
        }

        public async Task<int> Update(Person entity, IFormFile formFile)
        {
            if (formFile != null)
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine("wwwroot", "Image", Path.GetRandomFileName());
                    using (var stream = File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    entity.PersonImageURL = filePath;
                }

            await _repository.Update(entity);
            return entity.Id;
        }

        public async Task<int> Delete(Person entity)
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

        public async Task<Person> GetById(int Id)
        {
            var response = await _repository.GetById(Id);
            if (response == null)
                throw new Exception("Hata ById !");
            else
                return response;
        }


    }
}
