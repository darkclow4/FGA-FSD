using WebApplication1.Contexts;
using WebApplication1.Repository.Contracts;

namespace WebApplication1.Repository
{
    public class GeneralRepository<TEntity, TKey, TContext> : IGeneralRepository<TEntity, TKey>
    where TEntity : class
    where TContext : SQLServerContext
    {
        protected TContext _context;
        public GeneralRepository(TContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity? GetById(TKey key)
        {
            return _context.Set<TEntity>().Find(key);
        }

        public int Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(TKey key)
        {
            var entity = GetById(key);
            if (entity == null)
            {
                return 0;
            }

            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }
    }
}
