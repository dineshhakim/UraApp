using System;
using System.Collections.Generic;
using System.Linq.Expressions;
 

namespace UraApp.Repository.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(long id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where); 
    }
}