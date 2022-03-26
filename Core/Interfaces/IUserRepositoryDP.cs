using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepositoryDP
    {
        public Task<IEnumerable<UserModel>> GetUserByFilters(string filter, int numberPage);

        public Task<UserModel> GetById(int id);
    }
}
