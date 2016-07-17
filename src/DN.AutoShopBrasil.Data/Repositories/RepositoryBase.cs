using DN.AutoShopBrasil.Data.Context;
using DN.AutoShopBrasil.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DN.AutoShopBrasil.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly AutoShopBrasilContext DataContext;
        protected DbSet<TEntity> DbSet;
        public RepositoryBase(AutoShopBrasilContext context)
        {
            DataContext = context;
            DbSet = DataContext.Set<TEntity>();
        }
        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
        public virtual IEnumerable<TEntity> GetAllReadOnly()
        {
            return DbSet.AsNoTracking();
        }
        public void Update(TEntity obj)
        {
            var entry = DataContext.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            DataContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}