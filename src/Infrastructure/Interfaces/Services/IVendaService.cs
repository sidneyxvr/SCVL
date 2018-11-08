using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Services
{
    public interface IVendaService
    {
        Venda Add(Venda venda);
        void Update(Venda venda);
        void Remove(int id);
        Venda GetById(int id);
        IEnumerable<Venda> GetAll();
        double RateById(Guid id);
        IEnumerable<Venda> GetBySeller(Guid SellerId);
        IEnumerable<Venda> GetByCustomer(Guid CustomerId);
        void UpdateStatus(Venda venda);
        void UpdateSellerStatus(int id, int rate);
        int CountStatus(Guid userId, int status);
    }
}
