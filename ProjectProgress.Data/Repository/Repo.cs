using Microsoft.EntityFrameworkCore;
using ProjectProgress.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Data.Repository
{
    public class Repo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;

        public Repo(AppDbContext context)
        {
            _context = context;            
        }

        public async Task<TEntity> GET_ASYNC(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> FIND_ASYNC(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task CREATE_ASYNC(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task CREATES_ASYNC(IEnumerable<TEntity> entities)
        {
            try
            {
                await _context.Set<TEntity>().AddRangeAsync(entities);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UPDATE_ASYNC(TEntity entity)
        {
            try
            {
                 await Task.Run(()=> { _context.Set<TEntity>().Update(entity); });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UPDATES_ASYNC(IEnumerable<TEntity> entities)
        {
            try
            {
                await Task.Run(() => { _context.Set<TEntity>().UpdateRange(entities); });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DELETE_ASYNC(TEntity entity)
        {
            try
            {
                await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DELETES_ASYNC(IEnumerable<TEntity> entities)
        {
            try
            {
                await Task.Run(() => { _context.Set<TEntity>().RemoveRange(entities); });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
