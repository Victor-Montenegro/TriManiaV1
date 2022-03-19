using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User> 
    {
        public Task<List<User>> GetAllByPage(int page);

        public Task<User> GetUserByEmail(string email);

        public Task<User> GetUserByCpfOrCnpj(string taxNumber);

        public Task<User> GetUserByLogin(string login);

        public Task<User> GetUserByLoginAndPassworld(string login, string passworld);
    }
}
