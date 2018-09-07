using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure.Services
{
    public class ImagemService : IImagemService
    {
        private readonly IImagemRepository _repository;
        private readonly IHostingEnvironment _environment;

        public ImagemService(IImagemRepository repository, IHostingEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
        }

        public Imagem Add(IEnumerable<IFormFile> imagens, int id)
        {
            foreach (var imagem in imagens)
            {
                var cam = SaveImage(imagem);
                if(cam != null)
                {
                    var img = new Imagem
                    {
                        Caminho = cam,
                        AnuncioId = id
                    };
                    _repository.Add(img);
                }
            }
            return null;
        }
        
        public IEnumerable<Imagem> GetAll()
        {
            return _repository.GetAll();
        }

        public Imagem GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(Imagem imagem)
        {
            string caminho = _environment.WebRootPath + @"\Imagens\livros\";
            if (File.Exists(_environment.WebRootPath + imagem.Caminho))
            {
                File.Delete(_environment.WebRootPath + imagem.Caminho);
            }
            _repository.Remove(imagem.Id);
        }

        public string SaveImage(IFormFile imagem)
        {
            string caminho = _environment.WebRootPath + @"\images\livros\";
            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }
            if (imagem != null && imagem.Length > 0)
            {
                if (imagem.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(caminho, imagem.FileName), FileMode.Create, FileAccess.Write))
                    {
                        imagem.CopyTo(fileStream);
                    }
                    return @"\images\livros\" + imagem.FileName;
                }
            }
            return null;
        }

        public void Update(IFormFile imagemForm, Imagem imagem)
        {
            //string caminho = Path.Combine(_environment.WebRootPath, @"\Imagens\livros\");
            //var v = caminho;
            //if(File.Exists(_environment.WebRootPath + imagem.Caminho))
            //{
            //    File.Delete(_environment.WebRootPath + imagem.Caminho);
            //}
            imagem.Caminho = SaveImage(imagemForm);            
            _repository.Update(imagem);
        }
    }
}
