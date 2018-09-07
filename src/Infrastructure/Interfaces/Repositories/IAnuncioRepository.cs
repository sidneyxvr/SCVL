using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IAnuncioRepository : IRepositoryBase<Anuncio>
    {
        IEnumerable<string> GetAllCategory();
        IEnumerable<IGrouping<string, Anuncio>> GetGroupByCategory();
        IEnumerable<Anuncio> GetByCategory(string category);
        IEnumerable<Anuncio> Search(string search);
        IEnumerable<Anuncio> GetBySeller(Guid id);
        void Sell(int id);
    }
}
