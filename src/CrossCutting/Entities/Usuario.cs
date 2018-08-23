using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using ApplicationCore.Entities;

namespace CrossCutting.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Anuncio> Anuncios { get; set; }
    }
}
