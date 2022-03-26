using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private DbSet<Product> _dataSet;

        public ProductRepository(TriManiaContext context) : base(context)
        {
            _dataSet = context.Set<Product>();
        }

        public async Task<Product> GetProductByName(string name)
        {
            try
            {
                return await _dataSet.Where(x => x.Name == name && x.DeletionDate == null).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
