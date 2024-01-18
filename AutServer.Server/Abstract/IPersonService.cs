using AuthServer.Data.Entity;

namespace AutServer.Server.Abstract
{
    public interface IPersonService
    {
        Task<int> Add(Person entity);
        Task<int> Delete(Person entity);
        Task<int> Update(Person entity);
        Task<List<Person>> GetAll();
        Task<Person> GetById(int Id);
    }
}
