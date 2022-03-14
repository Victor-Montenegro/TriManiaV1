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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private DbSet<User> _dataSet;

        public UserRepository(TriManiaContext context) : base(context)
        {
            _dataSet = context.Set<User>();
        }

        public async Task<List<User>> GetAllByPage(int page)
        {
            try
            {
                //int count = await _dataSet.CountAsync();

                var result = await _dataSet.Skip(page * 10).Take(10).AsNoTracking().ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
