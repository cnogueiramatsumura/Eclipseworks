using DataAcess.Context;
using DataAcess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using System.Dynamic;

namespace DataAcess.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        public EclipseDBContext db;
        public RepositoryBase(EclipseDBContext _db)
        {
            db = _db;
        }

        public void Add(T obj)
        {
            db.Set<T>().Add(obj);
            db.SaveChanges();
        }

        public void Delete(T obj)
        {
            db.Entry(obj).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            T obj = GetById(id);
            db.Entry(obj).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return db.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
