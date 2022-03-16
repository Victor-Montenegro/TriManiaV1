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

                var result = await _dataSet.Where(x => x.DeletionDate == null).Skip(page * 10).Take(10).AsNoTracking().ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserByCpfOrCnpj(string taxNumber)
        {
            try
            {
                return await _dataSet.Where(x => x.Cpf == taxNumber && x.DeletionDate == null).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                return await _dataSet.Where(x => x.Email == email && x.DeletionDate == null).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
