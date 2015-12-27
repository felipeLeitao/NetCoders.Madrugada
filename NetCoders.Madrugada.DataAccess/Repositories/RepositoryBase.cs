using NetCoders.Madrugada.DataAccess.Context;
using NetCoders.Madrugada.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoders.Madrugada.DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbContext _db;

        public RepositoryBase(SisTinderContext db_)
        {
            _db = db_;
        }

        public void Create(T obj)
        {
            _db.Set<T>().Add(obj);
        }

        public IList<T> Read()
        {
            return _db.Set<T>().ToList();
        }

        public void Update(T obj)
        {

            _db.Entry(obj).State = EntityState.Modified;
        }

        public void Remove(T obj)
        {
            _db.Entry(obj).State = EntityState.Deleted;
        }

        public void RemoveRange(ICollection<T> collection_)
        {
            _db.Set<T>().RemoveRange(collection_);
        }

        public IList<T> Find(Expression<Func<T, bool>> filter_)
        {
            return _db.Set<T>().Where(filter_).ToList();
        }

        public IList<T> Join(Expression<Func<T, Object>> join_, Expression<Func<T, bool>> filter_)
        {
            return _db.Set<T>().Include(join_).Where(filter_).ToList();
        }
    }
}
