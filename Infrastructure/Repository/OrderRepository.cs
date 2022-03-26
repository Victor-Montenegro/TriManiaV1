using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private DbSet<Order> _dataSet;

        public OrderRepository(TriManiaContext context) : base(context)
        {
            _dataSet = context.Set<Order>();
        }

        public async Task<Order> GetOpenOrderByUserId(int userId)
        {
            try
            {
                return await _dataSet.Where(x => x.UserId == userId && !x.Status.Equals(OrderStatus.Cancelled) && !x.Status.Equals(OrderStatus.Completed) && x.DeletionDate == null).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}
