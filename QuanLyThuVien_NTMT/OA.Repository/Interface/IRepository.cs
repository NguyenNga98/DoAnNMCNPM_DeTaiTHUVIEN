using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OA.Data.Model;

namespace OA.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
        IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties);
        T GetSingle();
        void Update(T entity, params Expression<Func<T, object>>[] changedProperties);
    }
}
