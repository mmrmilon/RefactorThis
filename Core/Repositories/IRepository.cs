using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Insert(TEntity model, bool persist = false);

        IEnumerable<TEntity> BulkInsert(IEnumerable<TEntity> list);

        TEntity Update(TEntity model, bool persist = false);

        IEnumerable<TEntity> BulkUpdate(IEnumerable<TEntity> list);

        void Delete(long id, bool persist = false);

        void Delete(TEntity model, bool persist = false);

        bool BulkDelete(IEnumerable<TEntity> list);

        TEntity Get(object id);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();
    }
}
