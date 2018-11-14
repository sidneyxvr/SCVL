using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class Inicialize
    {
        public static void DbInicialize(SistemaDbContext context)
        {
            context.Database.EnsureCreated();
            
            if(context.Users.Count() == 0)
            {
                return;
            }

            var user = context.Users.First();

            if (context.Anuncios.Count() == 0)
            {
                var anuncios = new Anuncio[]
                {
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img1.jpg", Titulo = "Livro 1", DataCadastro = DateTime.Now, Autores = "Autor 20", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img2.jpg", Titulo = "Livro 2", DataCadastro = DateTime.Now, Autores = "Autor 18", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img3.jpg", Titulo = "Livro 3", DataCadastro = DateTime.Now, Autores = "Autor 16", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img4.jpg", Titulo = "Livro 4", DataCadastro = DateTime.Now, Autores = "Autor 14", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img5.jpg", Titulo = "Livro 5", DataCadastro = DateTime.Now, Autores = "Autor 12", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img6.jpg", Titulo = "Livro 6", DataCadastro = DateTime.Now, Autores = "Autor 10", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img7.jpg", Titulo = "Livro 7", DataCadastro = DateTime.Now, Autores = "Autor 8", Categoria = "Categoria 5", Editora = "Editora 2", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img8.jpg", Titulo = "Livro 8", DataCadastro = DateTime.Now, Autores = "Autor 6", Categoria = "Categoria 5", Editora = "Editora 2", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img9.jpg", Titulo = "Livro 9", DataCadastro = DateTime.Now, Autores = "Autor 4", Categoria = "Categoria 5", Editora = "Editora 2", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img10.jpg", Titulo = "Livro 10", DataCadastro = DateTime.Now, Autores = "Autor 2", Categoria = "Categoria 5", Editora = "Editora 2", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img11.jpg", Titulo = "Livro 11", DataCadastro = DateTime.Now, Autores = "Autor 19", Categoria = "Categoria 2", Editora = "Editora 3", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img12.jpg", Titulo = "Livro 12", DataCadastro = DateTime.Now, Autores = "Autor 17", Categoria = "Categoria 2", Editora = "Editora 3", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img13.jpg", Titulo = "Livro 13", DataCadastro = DateTime.Now, Autores = "Autor 15", Categoria = "Categoria 2", Editora = "Editora 3", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img14.jpg", Titulo = "Livro 14", DataCadastro = DateTime.Now, Autores = "Autor 13", Categoria = "Categoria 2", Editora = "Editora 3", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img15.jpg", Titulo = "Livro 15", DataCadastro = DateTime.Now, Autores = "Autor 11", Categoria = "Categoria 2", Editora = "Editora 3", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img16.jpg", Titulo = "Livro 16", DataCadastro = DateTime.Now, Autores = "Autor 9", Categoria = "Categoria 3", Editora = "Editora 4", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img17.jpg", Titulo = "Livro 17", DataCadastro = DateTime.Now, Autores = "Autor 7", Categoria = "Categoria 3", Editora = "Editora 4", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img18.jpg", Titulo = "Livro 18", DataCadastro = DateTime.Now, Autores = "Autor 5", Categoria = "Categoria 3", Editora = "Editora 4", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img19.jpg", Titulo = "Livro 19", DataCadastro = DateTime.Now, Autores = "Autor 3", Categoria = "Categoria 3", Editora = "Editora 4", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img20.jpg", Titulo = "Livro 20", DataCadastro = DateTime.Now, Autores = "Autor 1", Categoria = "Categoria 5", Editora = "Editora 4", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img21.jpg", Titulo = "Livro 21", DataCadastro = DateTime.Now, Autores = "Autor 20", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img22.jpg", Titulo = "Livro 22", DataCadastro = DateTime.Now, Autores = "Autor 18", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img23.jpg", Titulo = "Livro 23", DataCadastro = DateTime.Now, Autores = "Autor 16", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img24.jpg", Titulo = "Livro 24", DataCadastro = DateTime.Now, Autores = "Autor 14", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img25.jpg", Titulo = "Livro 25", DataCadastro = DateTime.Now, Autores = "Autor 12", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img26.jpg", Titulo = "Livro 26", DataCadastro = DateTime.Now, Autores = "Autor 10", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img27.jpg", Titulo = "Livro 27", DataCadastro = DateTime.Now, Autores = "Autor 8", Categoria = "Categoria 2", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img28.jpg", Titulo = "Livro 28", DataCadastro = DateTime.Now, Autores = "Autor 6", Categoria = "Categoria 2", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img29.jpg", Titulo = "Livro 29", DataCadastro = DateTime.Now, Autores = "Autor 4", Categoria = "Categoria 2", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img30.jpg", Titulo = "Livro 30", DataCadastro = DateTime.Now, Autores = "Autor 2", Categoria = "Categoria 2", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img31.jpg", Titulo = "Livro 31", DataCadastro = DateTime.Now, Autores = "Autor 19", Categoria = "Categoria 1", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img32.jpg", Titulo = "Livro 32", DataCadastro = DateTime.Now, Autores = "Autor 17", Categoria = "Categoria 1", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img33.jpg", Titulo = "Livro 33", DataCadastro = DateTime.Now, Autores = "Autor 15", Categoria = "Categoria 1", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img34.jpg", Titulo = "Livro 34", DataCadastro = DateTime.Now, Autores = "Autor 13", Categoria = "Categoria 1", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img35.jpg", Titulo = "Livro 35", DataCadastro = DateTime.Now, Autores = "Autor 11", Categoria = "Categoria 1", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img36.jpg", Titulo = "Livro 36", DataCadastro = DateTime.Now, Autores = "Autor 9", Categoria = "Categoria 5", Editora = "Editora 7", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img37.jpg", Titulo = "Livro 37", DataCadastro = DateTime.Now, Autores = "Autor 7", Categoria = "Categoria 5", Editora = "Editora 7", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img38.jpg", Titulo = "Livro 38", DataCadastro = DateTime.Now, Autores = "Autor 5", Categoria = "Categoria 5", Editora = "Editora 7", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img39.jpg", Titulo = "Livro 39", DataCadastro = DateTime.Now, Autores = "Autor 3", Categoria = "Categoria 5", Editora = "Editora 7", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img40.jpg", Titulo = "Livro 40", DataCadastro = DateTime.Now, Autores = "Autor 1", Categoria = "Categoria 5", Editora = "Editora 7", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img41.jpg", Titulo = "Livro 41", DataCadastro = DateTime.Now, Autores = "Autor 20", Categoria = "Categoria 4", Editora = "Editora 8", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img42.jpg", Titulo = "Livro 42", DataCadastro = DateTime.Now, Autores = "Autor 19", Categoria = "Categoria 4", Editora = "Editora 8", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img43.jpg", Titulo = "Livro 43", DataCadastro = DateTime.Now, Autores = "Autor 18", Categoria = "Categoria 4", Editora = "Editora 8", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img44.jpg", Titulo = "Livro 44", DataCadastro = DateTime.Now, Autores = "Autor 17", Categoria = "Categoria 4", Editora = "Editora 8", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img45.jpg", Titulo = "Livro 45", DataCadastro = DateTime.Now, Autores = "Autor 10", Categoria = "Categoria 5", Editora = "Editora 8", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img46.jpg", Titulo = "Livro 46", DataCadastro = DateTime.Now, Autores = "Autor 9", Categoria = "Categoria 5", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img47.jpg", Titulo = "Livro 47", DataCadastro = DateTime.Now, Autores = "Autor 8", Categoria = "Categoria 5", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img48.jpg", Titulo = "Livro 48", DataCadastro = DateTime.Now, Autores = "Autor 7", Categoria = "Categoria 2", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img49.jpg", Titulo = "Livro 49", DataCadastro = DateTime.Now, Autores = "Autor 6", Categoria = "Categoria 2", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img50.jpg", Titulo = "Livro 50", DataCadastro = DateTime.Now, Autores = "Autor 5", Categoria = "Categoria 2", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img51.jpg", Titulo = "Livro 51", DataCadastro = DateTime.Now, Autores = "Autor 4", Categoria = "Categoria 2", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img52.jpg", Titulo = "Livro 52", DataCadastro = DateTime.Now, Autores = "Autor 3", Categoria = "Categoria 2", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img53.jpg", Titulo = "Livro 53", DataCadastro = DateTime.Now, Autores = "Autor 2", Categoria = "Categoria 5", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, ImagemPrincipal = "/images/livros/img54.jpg", Titulo = "Livro 54", DataCadastro = DateTime.Now, Autores = "Autor 1", Categoria = "Categoria 5", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2}
                };

                foreach(var a in anuncios)
                {
                    Thread.Sleep(1000);
                    context.Anuncios.Add(a);
                }
                context.SaveChanges();
            }

            if(context.Imagens.Count() == 0)
            {
                var imagens = new List<Imagem>();
                var list = context.Anuncios;
                int j = 1;
                foreach (var i in list)
                {
                    imagens.Add(new Imagem() { AnuncioId = i.Id, Caminho = "/images/livros/img" + j.ToString() + ".jpg" });
                    j++;
                }

                context.Imagens.AddRange(imagens);
                context.SaveChanges();
            }
        }
    }
}
