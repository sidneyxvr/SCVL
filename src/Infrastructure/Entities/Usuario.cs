using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Anuncio> Anuncios { get; set; }
    }
}
