using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        private readonly DataBaseContext _context;
        internal DbSet<TEntity> dbSet;
        public Repository(DataBaseContext context) 
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var result = dbSet.Add(entity);
            return result.Entity;
        }
        public Task SaveAsync() =>
            _context.SaveChangesAsync();
    }
}