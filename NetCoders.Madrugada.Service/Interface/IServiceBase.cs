using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCoders.Madrugada.Service.Interface
{
    public interface IServiceBase<T> where T : class
    {
        void Create(T obj);

        IList<T> Read();

        void Update(T obj);

        void Remove(T obj);

        IList<T> Find(Expression<Func<T, bool>> filter_);

        IList<T> Join(Expression<Func<T, Object>> join_, Expression<Func<T, bool>> filter_);
    }
}
