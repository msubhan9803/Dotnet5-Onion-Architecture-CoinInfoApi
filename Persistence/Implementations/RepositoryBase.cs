using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Persistence.Implementations
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private AppDbContext Context { get; set; }

        protected RepositoryBase(AppDbContext context) {
            Context = context;
        }

        public IQueryable<T> GetAll()
        {
            return this.Context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.Context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.Context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
        }
    }
}