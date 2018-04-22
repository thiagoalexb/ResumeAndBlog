using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Resume.Core.Services.Base
{
    public interface IService<TEntity>
    {
        /// <summary>
        /// Add an Entity
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <param name="entity">The Entity</param>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Delete an Entity
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <param name="entity">The Entity</param>
        Task Delete(TEntity entity);

        /// <summary>
        /// Obtain first or something async generic Entity
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <param name="predicate">A criteria</param>
        /// <returns>An Entity or default</returns>
        Task<TEntity> GetByCriteriaAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Obtain the async list of Entities
        /// </summary>
        /// <returns>Async list of Entities</returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Obtain the async list of Entities
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllByCriteriaAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Obtain the async query of Entities
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAllQueryable();

        /// <summary>
        /// Obtain a list query of async generic Entities by criteria
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllQueryableByCriteria(Expression<Func<TEntity, bool>> predicate);
    }
}
