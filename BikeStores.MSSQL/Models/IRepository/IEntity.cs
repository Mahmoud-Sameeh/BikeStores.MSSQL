using BikeStores.MSSQL.Data;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.MSSQL.Models.IRepository
{
    public class Audit
    {

    }
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T FindById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private BikestoresContext _context;
        private DbSet<T> table;
        public GenericRepository()
        {
            this._context = new BikestoresContext();
            table = _context.Set<T>();
        }
        public GenericRepository(BikestoresContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }
        public void Delete(object id)
        {
            T existing = FindById(id);
            if (existing != null)
            table.Remove(existing);
        }

        public T FindById(object id)
        {
            return table.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public T GetById(object id) => table.Find(id);

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
