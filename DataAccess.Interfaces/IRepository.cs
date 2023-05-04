using Entities;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity,TKey>
        where TEntity : BaseEntity<TKey>
    {
        TEntity Add(TEntity entity);
        Task SaveAsync();
    }
}