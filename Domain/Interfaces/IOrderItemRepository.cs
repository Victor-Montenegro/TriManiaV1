using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        public Task<List<OrderItem>> GetAllOrderItemByOrderId(int orderId);

        public Task<OrderItem> GetOrderItemByOrderIdAndProductId(int orderId, int productId);

        public Task<OrderItem> GetOrderItemByOrderItemIdAndOrderId(int orderItemId, int orderId);
    }
}
