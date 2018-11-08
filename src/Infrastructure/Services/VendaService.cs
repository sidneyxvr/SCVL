using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;
        private readonly IAnuncioRepository _anuncioRepository;

        public VendaService()
        {
                
        }

        public VendaService(IVendaRepository repository, IAnuncioRepository anuncioRepository)
        {
            _repository = repository;
            _anuncioRepository = anuncioRepository;
        }

        public Venda Add(Venda venda)
        {
            try
            {
                venda.Id = 0;
                venda.Horario = DateTime.Now;
                _anuncioRepository.Sell(venda.AnuncioId);
                return _repository.Add(venda);
            }
            catch(Exception e)
            {
                var c = e.Message;
                return null;
            }
        }

        public IEnumerable<Venda> GetAll()
        {
            return _repository.GetAll();
        }

        public Venda GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Venda> GetByCustomer(Guid CustomerId)
        {
            return _repository.GetByCustomer(CustomerId);
        }

        public IEnumerable<Venda> GetBySeller(Guid SellerId)
        {
            return _repository.GetBySeller(SellerId);
        }

        public double RateById(Guid id)
        {
            return _repository.RateById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(Venda venda)
        {
            _repository.Update(venda);
        }

        public void UpdateStatus(Venda venda)
        {
            _repository.UpdateStatus(venda);
        }

        public void UpdateSellerStatus(int id, int rate)
        {
            _repository.UpdateSellerStatus(id, rate);
        }

        public int CountStatus(Guid userId,int status)
        {
            return _repository.CountStatus(userId, status);
        }
    }
}
