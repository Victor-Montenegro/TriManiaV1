using Domain.Entities.Base;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly TriManiaContext _context;

        private DbSet<T> _dataSet;

        public BaseRepository(TriManiaContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public async Task<T> Create(T data)
        {
            try
            {
                data.CreateDate = DateTime.Now;

                _context.Add(data);

                await _context.SaveChangesAsync();

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Delete(int id)
        {
            try
            {
                var result = await _dataSet.Where(x => x.Id == id).AsNoTracking().SingleOrDefaultAsync();

                if (result == null)
                    throw new Exception("Item não encontrado");

                _dataSet.Remove(result);

                await _context.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var result = await _dataSet.AsNoTracking().ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await _dataSet.Where(x => x.Id == id).AsNoTracking().SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Update(T data)
        {
            try
            {
                var result = await _dataSet.Where(x => x.Id == data.Id).AsNoTracking().SingleOrDefaultAsync();

                if (result == null)
                    throw new Exception("Item nao encontrado");

                data.CreateDate = DateTime.Now;

                _context.Entry(result).CurrentValues.SetValues(data);

                await _context.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
