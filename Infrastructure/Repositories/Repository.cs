using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public DatabaseContext dbContext { get; private set; }

        public DbSet<TEntity> Table
        {
            get
            {
                var context = ((IObjectContextAdapter)dbContext).ObjectContext;
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, dbContext.Set<TEntity>());

                return dbContext.Set<TEntity>();
            }
        }

        public Repository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(long id, bool persist = false)
        {
            var entity = this.Get(id);
            Table.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Delete(TEntity model, bool persist = false)
        {
            dbContext.Entry(model).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public TEntity Get(object id)
        {
            return Table.Find(id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Table.ToList();
        }

        public TEntity Insert(TEntity model, bool persist = false)
        {
            Table.Add(model);
            dbContext.SaveChanges();
            return model;
        }

        public TEntity Update(TEntity model, bool persist = false)
        {
            dbContext.Set<TEntity>().AddOrUpdate(model);
            dbContext.SaveChanges();
            return model;
        }

        public IEnumerable<TEntity> BulkInsert(IEnumerable<TEntity> list)
        {
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;

            foreach (var item in list)
                dbContext.Set<TEntity>().Add(item);

            dbContext.SaveChanges();

            return list;
        }

        public IEnumerable<TEntity> BulkUpdate(IEnumerable<TEntity> list)
        {
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;

            foreach (var item in list)
                dbContext.Set<TEntity>().AddOrUpdate(item);

            dbContext.SaveChanges();

            return list;
        }

        public bool BulkDelete(IEnumerable<TEntity> list)
        {
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;

            dbContext.Set<TEntity>().RemoveRange(list);
            dbContext.SaveChanges();

            return true;
        }
    }
}
