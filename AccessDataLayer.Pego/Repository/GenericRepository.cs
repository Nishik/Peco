using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Pego;
using System.Data.Entity;
using System.Data.Entity.Validation;
using AccessDataLayer.Pego.DataContext;
using System.Linq.Expressions;

namespace AccessDataLayer.Pego.Repository
{
    public class GenericRepository<T, TKey>: IRepository<T, TKey> where T : BaseEntity
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

        public virtual void Add(T item)
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
                        //msg += string.Format("Property: {0} Error: {1}",
                        //validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

      // TODO: Need to Decide to add async for Add, Update, Delete or not
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

        public virtual T GetById(TKey id)
        {
            return this.dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
                return this.dbSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.dbSet.ToListAsync();
        }

        public virtual T Find (Expression<Func<T,bool>> match)
        {
            return this.dbSet.SingleOrDefault(match);
        }

        public async Task<T> FindAsync (Expression<Func<T, bool>> match)
        {
            return await this.dbSet.SingleOrDefaultAsync(match);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match)
        {
            return this.dbSet.Where(match).ToList();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await this.dbSet.Where(match).ToListAsync();
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
