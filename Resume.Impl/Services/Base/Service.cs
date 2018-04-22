using Resume.Core.Repositories.Base;
using Resume.Core.Services.Base;
using Resume.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Impl.Services.Base
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Gets or Sets the Unit Of Work pattern <see cref="IUnitOfWork" />
        /// </summary>
        public IUnitOfWork UnitOfWork { get; private set; }

        /// <summary>
        /// Gets or sets repository instance used to perform database actions
        /// </summary>
        protected IRepository<TEntity> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity}" /> class
        /// </summary>
        /// <param name="unitOfWork">The implementation of Unit Of Work pattern <see cref="IUnitOfWork" /></param>
        public Service(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.Repository = this.UnitOfWork.Repository<TEntity>();
        }

        /// <inheritdoc/>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await this.Repository.AddAsync(entity);
            await this.UnitOfWork.CommitAsync();

            return entity;
        }
        
        /// <inheritdoc/>
        public async Task Delete(TEntity entity)
        {
            this.Repository.Delete(entity);

            await this.UnitOfWork.CommitAsync();
        }

        /// <inheritdoc/>
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> GetByCriteriaAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.Repository.GetByCriteriaAsync(predicate);
        }

        /// <inheritdoc/>
        public async Task<List<TEntity>> GetAllByCriteriaAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.Repository.GetAllByCriteriaAsync(predicate);
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> GetAllQueryable()
        {
            return this.Repository.GetAllQueryable();
        }
        
        /// <inheritdoc/>
        public IQueryable<TEntity> GetAllQueryableByCriteria(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Repository.GetAllQueryableByCriteria(predicate);
        }
    }
}
