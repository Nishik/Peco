using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessDataLayer.Pego.DataContext;
using AccessDataLayer.Pego.Repository;
using Model.Pego;

namespace AccessDataLayer.Pego
{
    public class UnitOfWork: IUnitOfWork
    {
        private PegoDB entities = null;


        public UnitOfWork()
        {
            this.entities = new PegoDB();
        }
        //TODO : or Hashtable?
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IRepository<T, TKey> Repository<T, TKey>() where T : BaseEntity
        {
             if (repositories.Keys.Contains(typeof(T)) == true)
                {
                    return repositories[typeof(T)] as IRepository<T, TKey>;
                }
                IRepository<T, TKey> repo = new GenericRepository<T, TKey>(entities);
                repositories.Add(typeof(T), repo);
                return repo;
            
        }

        public void Commit()
        {
            entities.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await entities.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entities.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
