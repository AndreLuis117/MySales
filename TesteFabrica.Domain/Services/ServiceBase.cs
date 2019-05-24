using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Domain.Interfaces;

namespace TesteFabrica.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {

        private readonly IBaseRepositorio<TEntity> repository;

        public ServiceBase(IBaseRepositorio<TEntity> repo)
        {
            repository = repo;
        }

        public void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }
    }
}
