using Domain.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task<T> Create(T data);

        public Task<T> Update(T data);

        public Task<T> Delete(int id);

        public Task<T> GetById(int id);

        public Task<IEnumerable<T>> GetAll();
    }
}
