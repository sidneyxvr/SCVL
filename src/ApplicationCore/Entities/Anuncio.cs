using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
