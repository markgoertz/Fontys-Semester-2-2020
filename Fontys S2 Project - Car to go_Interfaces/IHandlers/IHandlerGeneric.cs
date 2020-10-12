using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.IHandlers
{
    public interface IHandlerGeneric<T> where T : class
    {
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);


    }
}
