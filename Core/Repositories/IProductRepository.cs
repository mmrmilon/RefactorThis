using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Products> Get(Expression<Func<Products, bool>> predicate);

        IEnumerable<Products> GetAll();

        Products GetBy(long id);

        Products Insert(Products model);

        Products Update(Products model);

        bool Delete(long id);
    }
}
