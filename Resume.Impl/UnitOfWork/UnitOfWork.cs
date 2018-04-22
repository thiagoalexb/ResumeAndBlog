using Resume.Core.Repositories.Base;
using Resume.Core.UnitOfWork;
using Resume.Data.Contexts;
using Resume.Impl.Repositories.Base;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace Resume.Impl.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// A hash of repositories
        /// </summary>
        private Hashtable repositories;

        /// <summary>
        /// A pool of DBContext
        /// </summary>
        private IDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class
        /// </summary>
        /// <param name="context">Implementation of DBContext <see cref="IDbContext" /></param>
        public UnitOfWork(IDbContext context) => 
            this.context = context;

        /// <inheritdoc/>
        public async Task<bool> CommitAsync() => 
            await context.CommitAsync();

        /// <inheritdoc/>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (repositories.ContainsKey(type))
            {
                return (IRepository<TEntity>)this.repositories[type];
            }

            var repositoryType = typeof(Repository<TEntity>);

            repositories.Add(type, Activator.CreateInstance(repositoryType, this.context));

            return (IRepository<TEntity>)repositories[type];
        }
    }
}
