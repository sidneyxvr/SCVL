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
    }
}
