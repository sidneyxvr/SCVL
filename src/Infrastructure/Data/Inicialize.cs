using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 1", Autores = "Autor 20", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 2", Autores = "Autor 18", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 3", Autores = "Autor 16", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 4", Autores = "Autor 14", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 5", Autores = "Autor 12", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 6", Autores = "Autor 10", Categoria = "Categoria 1", Editora = "Editora 1", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 7", Autores = "Autor 8", Categoria = "Categoria 5", Editora = "Editora 2", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 8", Autores = "Autor 6", Categoria = "Categoria 5", Editora = "Editora 2", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 9", Autores = "Autor 4", Categoria = "Categoria 5", Editora = "Editora 2", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 10", Autores = "Autor 2", Categoria = "Categoria 5", Editora = "Editora 2", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 11", Autores = "Autor 19", Categoria = "Categoria 2", Editora = "Editora 3", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 12", Autores = "Autor 17", Categoria = "Categoria 2", Editora = "Editora 3", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 13", Autores = "Autor 15", Categoria = "Categoria 2", Editora = "Editora 3", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 14", Autores = "Autor 13", Categoria = "Categoria 2", Editora = "Editora 3", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 15", Autores = "Autor 11", Categoria = "Categoria 2", Editora = "Editora 3", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 16", Autores = "Autor 9", Categoria = "Categoria 3", Editora = "Editora 4", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 17", Autores = "Autor 7", Categoria = "Categoria 3", Editora = "Editora 4", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 18", Autores = "Autor 5", Categoria = "Categoria 3", Editora = "Editora 4", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 19", Autores = "Autor 3", Categoria = "Categoria 3", Editora = "Editora 4", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 20", Autores = "Autor 1", Categoria = "Categoria 5", Editora = "Editora 4", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 21", Autores = "Autor 20", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 22", Autores = "Autor 18", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 23", Autores = "Autor 16", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 24", Autores = "Autor 14", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 25", Autores = "Autor 12", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 26", Autores = "Autor 10", Categoria = "Categoria 4", Editora = "Editora 5", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 27", Autores = "Autor 8", Categoria = "Categoria 2", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 28", Autores = "Autor 6", Categoria = "Categoria 2", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 29", Autores = "Autor 4", Categoria = "Categoria 2", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 30", Autores = "Autor 2", Categoria = "Categoria 2", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 31", Autores = "Autor 19", Categoria = "Categoria 1", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 32", Autores = "Autor 17", Categoria = "Categoria 1", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 33", Autores = "Autor 15", Categoria = "Categoria 1", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 34", Autores = "Autor 13", Categoria = "Categoria 1", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 35", Autores = "Autor 11", Categoria = "Categoria 1", Editora = "Editora 6", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 36", Autores = "Autor 9", Categoria = "Categoria 5", Editora = "Editora 7", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 37", Autores = "Autor 7", Categoria = "Categoria 5", Editora = "Editora 7", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 38", Autores = "Autor 5", Categoria = "Categoria 5", Editora = "Editora 7", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 39", Autores = "Autor 3", Categoria = "Categoria 5", Editora = "Editora 7", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 40", Autores = "Autor 1", Categoria = "Categoria 5", Editora = "Editora 7", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 41", Autores = "Autor 20", Categoria = "Categoria 4", Editora = "Editora 8", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 42", Autores = "Autor 19", Categoria = "Categoria 4", Editora = "Editora 8", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 43", Autores = "Autor 18", Categoria = "Categoria 4", Editora = "Editora 8", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 44", Autores = "Autor 17", Categoria = "Categoria 4", Editora = "Editora 8", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 45", Autores = "Autor 10", Categoria = "Categoria 5", Editora = "Editora 8", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 46", Autores = "Autor 9", Categoria = "Categoria 5", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 47", Autores = "Autor 8", Categoria = "Categoria 5", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 48", Autores = "Autor 7", Categoria = "Categoria 2", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 49", Autores = "Autor 6", Categoria = "Categoria 2", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 50", Autores = "Autor 5", Categoria = "Categoria 2", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 51", Autores = "Autor 4", Categoria = "Categoria 2", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 52", Autores = "Autor 3", Categoria = "Categoria 2", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 53", Autores = "Autor 2", Categoria = "Categoria 5", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2},
                    new Anuncio(){UsuarioId = user.Id, Ativo = true, Titulo = "Livro 54", Autores = "Autor 1", Categoria = "Categoria 5", Editora = "Editora 9", Preco = 2.50M, QuantidadeDisponivel = 2}
                };

                context.Anuncios.AddRange(anuncios);
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
