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
            //var rate = _repository.Vendas.Where(v => v.VendedorId == id);
            //if(rate.Any())
            //{
            //    return rate.AsEnumerable().Average(v => v.Avaliacao);
            //}
            return 0.0;
        }

        //public override IEnumerable<Venda> GetAll()
        //{
        //    return _repository.Vendas.Include(a => a.Anuncio).Include(v => v.Vendedor).Include(c => c.Cliente).ToList();
        //}

        public override Venda GetById(int id)
        {
            //_repository.Vendas.Include(a => a.Anuncio).Include(v => v.Vendedor).Include(c => c.Cliente).Where(v => v.Id == id).First();
            return _repository.Vendas.Include(a => a.Anuncio).First();

        }

        public IEnumerable<Venda> GetVendasBySeller(Guid SellerId)
        {
            // _repository.Vendas.Include(a => a.Anuncio).Include(v => v.Vendedor).Include(c => c.Cliente).Where(v => v.VendedorId == SellerId);
            return _repository.Vendas.Include(v => v.Anuncio).OrderByDescending(v => v.Anuncio.DataCadastro); 
        }

        public IEnumerable<Venda> GetVendasByCustomer(Guid CustomerId)
        {
            return null; // _repository.Vendas.Include(a => a.Anuncio).Include(v => v.Vendedor).Include(c => c.Cliente).Where(v => v.ClienteId == CustomerId);
        }

        public void UpdateStatus(Venda venda)
        {
            _repository.Entry(venda).Property("Status").IsModified = true;
            _repository.SaveChanges();
        }
    }
}
