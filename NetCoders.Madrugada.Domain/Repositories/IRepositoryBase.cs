using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoders.Madrugada.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T obj);

        IList<T> Read();

        void Update(T obj);

        void Remove(T obj);

        void RemoveRange(ICollection<T> collection_);

        IList<T> Find(Expression<Func<T, bool>> filter_);

        IList<T> Join(Expression<Func<T, Object>> join_, Expression<Func<T, bool>> filter_);
    }
}
