using System;
using System.Collections.Generic;

namespace TMS.Repositroy.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> All();
        T GetById(int id);
        bool Exists(T entity);
        bool Insert(T entity, int id);
        bool Update(T entity);
        bool Delete(T entity);
        int Count(T entity);
    }
}
