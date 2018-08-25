using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _repository;

        public AnuncioService(IAnuncioRepository repository)
        {
            _repository = repository;
        }

        public Anuncio Add(Anuncio anuncio)
        {
            return _repository.Add(anuncio);
        }

        public IEnumerable<Anuncio> GetAll()
        {
            return _repository.GetAll();
        }

        public Anuncio GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(Anuncio anuncio)
        {
            _repository.Update(anuncio);
        }
    }
}
