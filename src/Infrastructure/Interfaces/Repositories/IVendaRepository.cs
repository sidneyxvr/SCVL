using Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IVendaRepository : IRepositoryBase<Venda>
    {
        double RateById(Guid id);
        IEnumerable<Venda> GetVendasBySeller(Guid SellerId);
        IEnumerable<Venda> GetVendasByCustomer(Guid CustomerId);
        void UpdateStatus(Venda venda);
    }
}
