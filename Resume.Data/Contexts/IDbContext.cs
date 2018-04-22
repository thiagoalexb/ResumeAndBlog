using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Resume.Data.Contexts
{
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// Add an Entity
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <param name="entity">The Entity</param>
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Delete an Entity
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <param name="entity">The Entity</param>
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Obtain first or something async generic Entity
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <param name="predicate">A criteria</param>
        /// <returns>An Entity or default</returns>
        Task<TEntity> GetByCriteriaAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        /// <summary>
        /// Obtain a list of async generic Entities
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <returns>A list of async generic Entities</returns>
        Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class;

        /// <summary>
        /// Obtain a list of async generic Entities by criteria
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        Task<List<TEntity>> GetAllByCriteriaAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        /// <summary>
        /// Obtain a list query of async generic Entities
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <returns>A list query of async generic Entities</returns>
        IQueryable<TEntity> GetAllQueryable<TEntity>() where TEntity : class;

        /// <summary>
        /// Obtain a list query of async generic Entities by criteria
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <returns>A list query of async generic Entities</returns>
        IQueryable<TEntity> GetAllQueryableByCriteria<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        
        /// <summary>
        ///  Do an async commit
        /// </summary>
        /// <returns>An identifier value</returns>
        Task<bool> CommitAsync();
    }
}
