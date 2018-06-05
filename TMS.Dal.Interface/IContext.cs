using System;
using System.Collections.Generic;

namespace TMS.Dal.Interface
{
    public interface IContext<T>
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
