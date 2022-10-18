using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarmaModels.KarmaModels;

namespace KarmaModels.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly KarmaDBContext _context = null;
        private DbSet<T> table = null;
        public Repository()
        {
            this._context = new KarmaDBContext();
            table = _context.Set<T>();
        }
        public void Add(T entity)
        {
            table.Add(entity);
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
