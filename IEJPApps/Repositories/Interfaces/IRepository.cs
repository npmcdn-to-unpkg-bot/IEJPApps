using System;
using System.Collections.Generic;

namespace IEJPApps.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        List<T> GetAll();
        T GetByID(Guid id);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}