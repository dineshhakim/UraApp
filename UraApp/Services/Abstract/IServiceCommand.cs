using System.Collections.Generic;

namespace UraApp.Services.Abstract
{
    public interface IServiceCommand<T>
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T GetById(long id);
    }
}