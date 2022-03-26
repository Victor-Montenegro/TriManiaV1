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
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {

        private DbSet<Address> _dataSet;

        public AddressRepository(TriManiaContext context) : base(context)
        {
            _dataSet = context.Set<Address>();
        }

        public async Task<Address> GetAddressByUserId(long userId)
        {
            try
            {
                return await _dataSet.Where(x => x.User.Id == userId && x.DeletionDate == null).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Address>> GetAllAddress()
        {
            throw new NotImplementedException();
        }
    }
}
