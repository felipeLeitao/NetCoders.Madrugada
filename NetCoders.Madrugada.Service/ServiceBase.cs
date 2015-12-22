using NetCoders.Madrugada.Domain.Repositories;
using NetCoders.Madrugada.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCoders.Madrugada.Service
{
    public abstract class ServiceBase<T> :  IServiceBase<T> where T : class
    {
        public readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository_)
        {
            _repository = repository_;
        }

        public void Create(T obj)
        {
            _repository.Create(obj);
        }

        public IList<T> Read()
        {
            return _repository.Read();
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }

        public void Remove(T obj)
        {
            _repository.Remove(obj);
        }

        public IList<T> Find(Expression<Func<T, bool>> filter_)
        {
            return _repository.Find(filter_);
        }

        public IList<T> Join(Expression<Func<T, Object>> join_, Expression<Func<T, bool>> filter_)
        {
            return _repository.Join(join_, filter_);
        }
    }
}
