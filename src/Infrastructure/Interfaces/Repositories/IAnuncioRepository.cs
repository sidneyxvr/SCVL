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
    }
}
