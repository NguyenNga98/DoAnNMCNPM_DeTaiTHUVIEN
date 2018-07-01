using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OA.Data;
using OA.Data.Model;
using OA.Repository.Interface;

namespace OA.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ThuVienContext _context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ThuVienContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(s =>s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity, params string[] changedProperties)
        {
            TryAttach(entity);

            changedProperties = changedProperties?.Distinct().ToArray();

            if (changedProperties?.Any() == true)
            {
                foreach (var property in changedProperties)
                {
                    _context.Entry(entity).Property(property).IsModified = true;
                }
            }
            else
                _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = entities.AsNoTracking();
            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);
            return query;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public T GetSingle()
        {
            return entities.FirstOrDefault();
        }
        public virtual void Update(T entity, params Expression<Func<T, object>>[] changedProperties)
        {

            changedProperties = changedProperties?.Distinct().ToArray();

            if (changedProperties?.Any() == true)
            {
                foreach (var property in changedProperties)
                {
                    _context.Entry(entity).Property(property).IsModified = true;
                }
            }
            else
                _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        protected void TryAttach(T entity)
        {
            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _context.Attach(entity);
                }
            }
            catch
            {
                // ignored
            }
        }
    }

}
