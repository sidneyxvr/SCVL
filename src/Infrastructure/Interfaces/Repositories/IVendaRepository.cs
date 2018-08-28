using Infrastructure.Entities;
using System;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IVendaRepository : IRepositoryBase<Venda>
    {
        double RateById(Guid id);
    }
}
