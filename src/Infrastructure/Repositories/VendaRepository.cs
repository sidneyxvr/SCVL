using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        public VendaRepository(SistemaDbContext repository)
            : base(repository)
        {

        }

        public double RateById(Guid id)
        {
            return _repository.Vendas.Where(v => v.VendedorId == id).AsEnumerable().Average(v => v.Avaliacao);
        }

        public override IEnumerable<Venda> GetAll()
        {
            return _repository.Vendas.Include(a => a.Anuncio).Include(v => v.Vendedor).Include(c => c.Cliente).ToList();
        }

        public override Venda GetById(int id)
        {
            return _repository.Vendas.Include(a => a.Anuncio).Include(v => v.Vendedor).Include(c => c.Cliente).Where(v => v.Id == id).First();
        }
    }
}
