using Infrastructure.Data;
using Infrastructure.Interfaces.Repositories;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly SistemaDbContext _repository;

        public RepositoryBase(SistemaDbContext repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Set<TEntity>().Add(obj);
            _repository.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _repository.Set<TEntity>().Find(id);
        }

        public virtual void Remove(int id)
        {
            var entity = _repository.Set<TEntity>().Find(id);
            _repository.Set<TEntity>().Remove(entity);
            _repository.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _repository.Set<TEntity>().Update(obj);
            _repository.SaveChangesAsync();
        }
    }
}
