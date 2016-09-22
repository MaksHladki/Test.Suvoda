using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MaksimHladki.DAL.Common
{
    public interface IRepository<T> where T : class
    {
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(object id);
        T GetById(object id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByQuery(
            Expression<Func<T, bool>> query = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
    }
}