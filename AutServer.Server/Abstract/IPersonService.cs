using AuthServer.Data.Entity;
using Microsoft.AspNetCore.Http;

namespace AutServer.Server.Abstract
{
    public interface IPersonService
    {
        Task<long> Add(Person entity, IFormFile formFile);
        Task<long> Delete(Person entity);
        Task<long> Update(Person entity, IFormFile formFile);
        Task<List<Person>> GetAll();
        Task<Person> GetById(long Id);
    }
}
