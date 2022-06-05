using AdsOnline.Models.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdsOnline.Models.Data.Concrete
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }
        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}