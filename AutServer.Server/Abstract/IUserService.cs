using AuthServer.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutServer.Server.Abstract
{
    public interface IUserService
    {
        Task<long> Add(User entity);        
        Task<long> Update(User entity);
        Task<List<User>> GetAll();
        Task<User> GetByUserName(string UserName);
    }
}

