using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        private DbSet<OrderItem> _dataSet;

        public OrderItemRepository(TriManiaContext context) : base(context)
        {
            _dataSet = context.Set<OrderItem>();
        }

        public async Task<List<OrderItem>> GetAllOrderItemByOrderId(int orderId)
        {
            try
            {
                return await _dataSet.Where(x => x.OrderId.Equals(orderId) && x.DeletionDate == null).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderItem> GetOrderItemByOrderIdAndProductId(int orderId, int productId)
        {
            try
            {
                return await _dataSet.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId.Equals(productId) && x.OrderId.Equals(orderId) && x.DeletionDate == null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderItem> GetOrderItemByOrderItemIdAndOrderId(int orderItemId, int orderId)
        {
            try
            {
                return await _dataSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == orderItemId && x.OrderId == orderId && x.DeletionDate == null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
