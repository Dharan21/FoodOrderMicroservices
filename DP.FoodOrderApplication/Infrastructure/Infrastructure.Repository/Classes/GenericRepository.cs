using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Classes
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly DbContext Context;
        private readonly DbSet<T> Entities;
        public GenericRepository(DbContext dbContext)
        {
            this.Context = dbContext;
            Entities = Context.Set<T>();
        }
        public async Task<List<T>> GetAll()
        {
            return await Entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task Create(T entity)
        {
            await Entities.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            try
            {
                var entity = await Context.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    return entity;
                }

                Context.Set<T>().Remove(entity);
                await Context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            try
            {
                return await Entities.Where(match).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            try
            {
                return await Entities.Where(match).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        { }
    }
}
