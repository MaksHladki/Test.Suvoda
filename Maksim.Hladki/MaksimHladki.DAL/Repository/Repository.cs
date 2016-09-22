using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MaksimHladki.DAL.Common;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected Entities DbContext;
        protected DbSet<T> DbSet;

        public Repository(DbContext dbContext)
        {
            DbContext = (Entities)dbContext;
            DbSet = dbContext.Set<T>();
        }

        public void Delete(T entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Deleted)
                DbSet.Attach(entity);

            DbSet.Remove(entity);
        }

        public void DeleteById(object id)
        {
            var entity = DbSet.Find(id);
            Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable();
        }

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetByQuery(
            Expression<Func<T, bool>> query = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> queryResult = DbSet;

            if (query != null)
            {
                queryResult = queryResult.Where(query);
            }

            foreach (var property in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                queryResult = queryResult.Include(property);
            }

            if (orderBy != null)
            {
                return orderBy(queryResult);
            }

            return queryResult;
        }

        public T Insert(T entity)
        {
            return DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}