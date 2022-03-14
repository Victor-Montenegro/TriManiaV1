using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User> 
    {
        public Task<List<User>> GetAllByPage(int page);
    }
}
