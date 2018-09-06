using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            anuncio.DataCadastro = DateTime.Now;
            return _repository.Add(anuncio);
        }

        public IEnumerable<Anuncio> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<string> GetAllCategory()
        {
            return _repository.GetAllCategory();
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
        
        public List<Tuple<string, IEnumerable<Anuncio>>> GetGroupByCategory(int amountByCategory)
        {
            List<Tuple<string, IEnumerable<Anuncio>>> tuples = new List<Tuple<string, IEnumerable<Anuncio>>>();
            var groupby = _repository.GetGroupByCategory();
            foreach (var group in groupby)
            {
                tuples.Add(new Tuple<string, IEnumerable<Anuncio>>(group.Key, group.AsEnumerable().OrderByDescending(a => a.DataCadastro).Take(amountByCategory)));
            }
            return tuples;
        }

        public IEnumerable<Anuncio> GetByCategory(string category)
        {
            return _repository.GetByCategory(category);
        }

        public IEnumerable<Anuncio> Search(string search)
        {
            return _repository.Search(search);
        }
    }
}
