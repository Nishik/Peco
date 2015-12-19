using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Model.Pego;

namespace AccessDataLayer.Pego.Repository
{
   public interface IRepository<T, TKey> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(TKey id);
        Task<T> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();
        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
    }
}
