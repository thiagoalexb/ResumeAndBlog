using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Resume.Data.Contexts
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }

        /// <inheritdoc/>
        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class =>
            await Set<TEntity>().AddAsync(entity);

        /// <inheritdoc/>
        public void Delete<TEntity>(TEntity entity) where TEntity : class =>
            Set<TEntity>().Remove(entity);

        /// <inheritdoc/>
        public async Task<TEntity> GetByCriteriaAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class =>
            await Set<TEntity>().FirstOrDefaultAsync(predicate);

        /// <inheritdoc/>
        public async Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class =>
            await this.Set<TEntity>().ToListAsync();

        /// <inheritdoc/>
        public async Task<List<TEntity>> GetAllByCriteriaAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class =>
            await this.Set<TEntity>().Where(predicate).ToListAsync();

        /// <inheritdoc/>
        public IQueryable<TEntity> GetAllQueryable<TEntity>() where TEntity : class =>
            Set<TEntity>().AsQueryable();

        /// <inheritdoc/>
        public IQueryable<TEntity> GetAllQueryableByCriteria<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class =>
            Set<TEntity>().Where(predicate).AsQueryable();

        /// <inheritdoc/>
        public async Task<bool> CommitAsync() =>
            await this.SaveChangesAsync() > 0;
    }
}
