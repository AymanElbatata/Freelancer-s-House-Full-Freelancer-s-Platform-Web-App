using AymanFreelance.BLL.Interfaces;
using AymanFreelance.DAL.Contexts;
using AymanFreelance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AymanFreelance.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AymanFreelanceDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AymanFreelanceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }

        public int Add(T obj)
        {
            _context.Set<T>().Add(obj);
            return _context.SaveChanges();
        }

        //public int Delete(T obj)
        //{
        //    _context.Set<T>().Remove(obj);
        //    return _context.SaveChanges();
        //}

        public IEnumerable<T> GetAll()
            => _context.Set<T>().ToList();

        //public IEnumerable<T> GetAllCustomized(
        //Expression<Func<T, bool>> filter = null,
        //Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //params Expression<Func<T, object>>[] includes)
        //{
        //    IQueryable<T> query = _dbSet;

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    // Include related entities
        //    if (includes != null)
        //    {
        //        query = includes.Aggregate(query, (current, include) => current.Include(include));
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

            public IEnumerable<T> GetAllCustomized(
        Expression<Func<T, bool>> filter = null,
        params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Include related entities
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query.ToList();
        }


        public T GetById(int? id)
            => _context.Set<T>().Find(id);

        public int Update(T obj)
        {
            _context.Set<T>().Update(obj);
            return _context.SaveChanges();
        }
    }
}
