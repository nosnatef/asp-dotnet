using Microsoft.EntityFrameworkCore;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        // readonly can only be initialized in the constructor
        protected readonly MovieShopDbContext _dbContext;

        public EfRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int Id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(Id);
            return entity;
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter)
        {
            if(filter != null)
            {
                return await _dbContext.Set<T>().Where(filter).CountAsync();
            }
            else
            {
                return await _dbContext.Set<T>().CountAsync();
            }
        }

        public async Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter)
        {
            if (filter != null)
            {
                return await _dbContext.Set<T>().Where(filter).AnyAsync();
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }

        // connected entities and disconnected
        // var test = new Movie { id = 24, title = "abc" };
        // _dbContext.add(test);
        // _dbContext.saveChanges();

        // var dbMovie = dbContext.Movies.Find(23);
        // dbMovie.Revenue = 200000;
        // dbContext.Update();
        // dbContext.SaveChanges();

        // stateless: every request is independent of each other
        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
