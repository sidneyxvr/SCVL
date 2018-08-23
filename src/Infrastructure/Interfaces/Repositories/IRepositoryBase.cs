using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
