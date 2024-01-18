using AuthServer.Data.Entity;
using Microsoft.AspNetCore.Http;

namespace AutServer.Server.Abstract
{
    public interface IPersonService
    {
        Task<int> Add(Person entity, IFormFile formFile);
        Task<int> Delete(Person entity);
        Task<int> Update(Person entity, IFormFile formFile);
        Task<List<Person>> GetAll();
        Task<Person> GetById(int Id);
    }
}
