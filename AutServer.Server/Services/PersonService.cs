using AuthServer.Data.Entity;
using AuthServer.Data.Repository;
using AutServer.Server.Abstract;

namespace AutServer.Server.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<int> Add(Person entity)
        {
            await _repository.Add(entity);
            return entity.Id;
        }

        public async Task<int> Update(Person entity)
        {
            if (entity == null)
            {
                throw new Exception("Hata Update !");
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
            return await _repository.GetById(Id);
        }


    }
}
