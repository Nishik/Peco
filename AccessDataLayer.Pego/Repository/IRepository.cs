using System;
using System.Collections.Generic;
using Model.Pego;

namespace AccessDataLayer.Pego.Repository
{
   public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Find(object id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
    }
}
