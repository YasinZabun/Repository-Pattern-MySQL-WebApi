using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repositories.Providers
{
   public class Repository<T> : IRepository<T> where T : class
    {
        private Expression<Func<T, bool>> GetGlobalExpression()
        {
             return x => true;
            /**/           
            //return x => DateTime.Now.Hour > 7;
        }
        protected DbContext DbContext;
        protected DbSet<T> DbSet;
        public Repository(DbContext dbcontext)
        {
            DbContext = dbcontext;
            DbSet = DbContext.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity, bool forceDelete = false)
        {
            DbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> iQueryable = DbSet
                .Where(GetGlobalExpression())
                .Where(predicate);
            return iQueryable;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Update(T entity)
        {

            DbSet.Update(entity);
            //DbSet.Attach(entity);
           //DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
