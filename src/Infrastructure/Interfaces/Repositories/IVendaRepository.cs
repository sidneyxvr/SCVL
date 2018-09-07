using Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IVendaRepository : IRepositoryBase<Venda>
    {
        double RateById(Guid id);
        IEnumerable<Venda> GetBySeller(Guid SellerId);
        IEnumerable<Venda> GetByCustomer(Guid CustomerId);
        void UpdateStatus(Venda venda);
        void UpdateSellerStatus(int id, int rate);
    }
}
