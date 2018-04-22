using Resume.Core.Repositories.Base;
using Resume.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Impl.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The DataBase Context
        /// </summary>
        protected readonly IDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}" /> class
        /// </summary>
        /// <param name="context">The implementation of Database Context <see cref="IDbContext" /></param>
        public Repository(IDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task AddAsync(TEntity entity) =>
            await context.AddAsync<TEntity>(entity);

        /// <inheritdoc/>
        public void Delete(TEntity entity) =>
            context.Delete<TEntity>(entity);

        /// <inheritdoc/>
        public Task<List<TEntity>> GetAllAsync() =>
            context.GetAllAsync<TEntity>();

        /// <inheritdoc/>
        public async Task<TEntity> GetByCriteriaAsync(Expression<Func<TEntity, bool>> predicate) =>
            await context.GetByCriteriaAsync<TEntity>(predicate);

        /// <inheritdoc/>
        public async Task<List<TEntity>> GetAllByCriteriaAsync(Expression<Func<TEntity, bool>> predicate) =>
            await context.GetAllByCriteriaAsync<TEntity>(predicate);

        /// <inheritdoc/>
        public IQueryable<TEntity> GetAllQueryable() =>
            context.GetAllQueryable<TEntity>();

        /// <inheritdoc/>
        public IQueryable<TEntity> GetAllQueryableByCriteria(Expression<Func<TEntity, bool>> predicate) => 
            context.GetAllQueryableByCriteria<TEntity>(predicate);
    }
}
