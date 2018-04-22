using Resume.Core.Repositories.Base;
using System.Threading.Tasks;

namespace Resume.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Obtain a generic repository
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <returns>A generic repository</returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        /// <summary>
        /// Do the context commit async
        /// </summary>
        /// <returns>An identifier value</returns>
        Task<bool> CommitAsync();
    }
}
