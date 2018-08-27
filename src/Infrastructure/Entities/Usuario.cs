using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Usuario : IdentityUser<Guid>
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Anuncio> Anuncios { get; set; }
        public IEnumerable<Venda> VendasVendedor { get; set; }
        public IEnumerable<Venda> VendasCliente{ get; set; }
    }
}
