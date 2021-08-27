using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepository<Products> repository;

        public ProductRepository(IRepository<Products> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Products> Get(Expression<Func<Products, bool>> predicate)
        {
            return repository.Get(predicate);
        }

        public IEnumerable<Products> GetAll()
        {
            return repository.GetAll();
        }

        public Products GetBy(long id)
        {
            return repository.Get(id);
        }

        public Products Insert(Products model)
        {
            return repository.Insert(model);
        }

        public Products Update(Products model)
        {
            return repository.Update(model);
        }

        public bool Delete(long id)
        {
            repository.Delete(id);

            return true;
        }
    }
}
