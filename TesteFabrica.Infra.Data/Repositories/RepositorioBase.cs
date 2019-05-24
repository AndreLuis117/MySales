using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFabrica.Domain.Interfaces;
using TesteFabrica.Infra.Data.Contexto;
using System.Data.Entity;

namespace TesteFabrica.Infra.Data.Repositories
{
    public class RepositorioBase<TEntity> : IDisposable, IBaseRepositorio<TEntity> where TEntity : class
    {

        protected TesteFabricaContext Db = new TesteFabricaContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

       
    }
}
