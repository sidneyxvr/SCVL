using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AnuncioRepository : RepositoryBase<Anuncio>, IAnuncioRepository
    {
        public AnuncioRepository(SistemaDbContext context)
            : base(context)
        {
             
        }

        public override void Remove(int id)
        {
            var anuncio = _repository.Anuncios.Find(id);
            anuncio.Ativo = false;
            _repository.Anuncios.Update(anuncio);
            _repository.SaveChanges();
        }

        public override void Update(Anuncio anuncio)
        {
            _repository.Entry(anuncio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _repository.SaveChanges();
        }

        public override IEnumerable<Anuncio> GetAll()
        {
            return _repository.Anuncios.Include(a => a.Imagens)
                                       .Include(a => a.Usuario)
                                       .Where(a => a.QuantidadeDisponivel > 0)
                                       .OrderByDescending(a => a.DataCadastro)
                                       .ToList();
        }

        public override Anuncio GetById(int id)
        {
            return _repository.Anuncios.Include(a => a.Imagens)
                                       .Include(a => a.Usuario)
                                       .Where(a => a.Id == id)
                                       .First();
        }

        public IEnumerable<string> GetAllCategory()
        {
            return _repository.Anuncios.Where(a => a.Ativo == true)
                                       .OrderBy(a => a.Categoria)
                                       .Select(a => a.Categoria)
                                       .Distinct();
        }

        public IEnumerable<IGrouping<string, Anuncio>> GetGroupByCategory()
        {
            return _repository.Anuncios.Include(a => a.Imagens)
                                       .Include(a => a.Usuario)
                                       .Where(a => a.Ativo == true 
                                              && a.QuantidadeDisponivel > 0)
                                       .ToList()
                                       .OrderBy(a => a.Categoria)
                                       .GroupBy(a => a.Categoria);
        }

        public IEnumerable<Anuncio> GetByCategory(string category)
        {
            return _repository.Anuncios.Include(i => i.Imagens)
                                       .Where(a => a.Ativo == true && a.Categoria == category)
                                       .OrderByDescending(a => a.DataCadastro);
        }

        public IEnumerable<Anuncio> Search(string search)
        {
            return _repository.Anuncios.Include(i => i.Imagens)
                                       .Where(a => (a.Titulo.Contains(search)
                                              || a.Autores.Contains(search)
                                              || a.Categoria.Contains(search)) && a.Ativo == true)
                                       .OrderByDescending(i => i.DataCadastro);
        }

        public IEnumerable<Anuncio> GetBySeller(Guid id)
        {
            return _repository.Anuncios.Include(i => i.Usuario)
                                       .Where(a => a.UsuarioId == id)
                                       .OrderByDescending(a => a.DataCadastro);
        }

        public void Sell(int id)
        {
            var anuncio = _repository.Anuncios.Find(id);
            anuncio.QuantidadeDisponivel--;
            _repository.Anuncios.Update(anuncio);
            _repository.SaveChanges();
        }
    }
}
