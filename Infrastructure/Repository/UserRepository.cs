using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
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

        public Task<User> GetUserByLogin(string login)
        {
            try
            {
                return _dataSet.Where(x => x.Login == login && x.DeletionDate == null).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<User> GetUserByLoginAndPassworld(string login, string passworld)
        {
            try
            {
                return _dataSet.Where(x => x.Login == login && x.Passworld == passworld && x.DeletionDate == null).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
