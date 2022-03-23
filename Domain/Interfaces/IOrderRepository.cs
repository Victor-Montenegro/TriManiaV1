using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public Task<Order> GetOpenOrderByUserId(int userId);
    }
}
