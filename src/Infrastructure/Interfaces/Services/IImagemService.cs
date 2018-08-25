using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Services
{
    public interface IImagemService
    {
        Imagem Add(IEnumerable<IFormFile> imagens, int id);
        void Update(IFormFile imagemForm, Imagem imagem);
        void Remove(Imagem imagem);
        Imagem GetById(int id);
        IEnumerable<Imagem> GetAll();
        string SaveImage(IFormFile imagem);
    }
}
