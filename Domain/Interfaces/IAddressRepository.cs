using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        public Task<List<Address>> GetAllAddress();

        public Task<Address> GetAddressByUserId(long userId);
    }
}
