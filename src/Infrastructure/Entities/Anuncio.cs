using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autores { get; set; }
        public string Editora { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Imagem> Imagens { get; set; }
    }
}
