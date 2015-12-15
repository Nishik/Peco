using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Pego;
using System.Data.Entity;
using System.Data.Entity.Validation;
using AccessDataLayer.Pego.DataContext;
//https://code.msdn.microsoft.com/Repository-Pattern-in-MVC5-0bf41cd0
//http://stackoverflow.com/questions/22221457/usermanager-createasyncuser-password-stuck-in-infinite-loop

namespace AccessDataLayer.Pego.Repository
{
    // добавил Tkey проверить
    public class GenericRepository<T, TKey>: IRepository<T> where T : BaseEntity
    {
        private PegoDB _context;
        private DbSet<T> _dbSet;


        public DbSet<T> dbSet
        {
            get
            {
                if (_dbSet == null)
                {
                    _dbSet = _context.Set<T>();
                }
                return _dbSet;
            }
        }

        public GenericRepository(PegoDB context)
        {
            this._context = context;
        }

        public virtual void Insert(T item)
        {
            try
            {
                if (dbSet == null)
                {
                    throw new ArgumentException("dbSet");
                }
                this.dbSet.Add(item);
                Save();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public virtual void Delete(T id)
        {
            try
            {
                if (dbSet == null)
                {
                    throw new ArgumentException("dbSet");
                }
                this.dbSet.Remove(id);
                Save();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;

            }
        }

        public virtual T GetById(object id)
        {
            return this.dbSet.Find(id);
        }
      
        public Task<T> GetByIdAsync (object id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.dbSet;
        }

        public virtual void Save()
        {
            this._context.SaveChanges();
        }

        public virtual void Update(T item)
        {
            try
            {
                if (dbSet == null)
                {
                    throw new ArgumentException("dbSet");
                }
                _context.Entry(item).State = EntityState.Modified;
                Save();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }



    }
}
