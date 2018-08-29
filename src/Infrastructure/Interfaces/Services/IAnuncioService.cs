using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Infrastructure.Interfaces.Services
{
    public interface IAnuncioService
    {
        Anuncio Add(Anuncio anuncio);
        void Update(Anuncio anuncio);
        void Remove(int id);
        Anuncio GetById(int id);
        IEnumerable<Anuncio> GetAll();
        IEnumerable<string> GetAllCategory();
        List<Tuple<string, IEnumerable<Anuncio>>> GetGroupByCategory(int amountByCategory);
    }
}
