using CashBasis.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CashBasis.DAL.Implementation
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public virtual T Delete(int Id)
        {
            var entity = FindById(Id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
            return entity;
        }

        public virtual T FindById(int Id)
        {
            var result = _dbSet.Find(Id);
            return result;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public virtual T Update(int id, T newEntity)
        {
            var entity = FindById(id);
            if (entity != null)
            {
                _context.Entry(entity).CurrentValues.SetValues(newEntity);
            }

            return entity;
        }

    }
}
