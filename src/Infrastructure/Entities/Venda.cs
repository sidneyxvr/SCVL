using Infrastructure.Enum;
using System;

namespace Infrastructure.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Horario { get; set; }
        public int Status { get; set; }
        public int FormaPagamento { get; set; }
        public int Avaliacao { get; set; }
        public int AnuncioId { get; set; }
        public Anuncio Anuncio { get; set; }
        public Guid VendedorId { get; set; }
        public Usuario Vendedor { get; set; }
        public Guid ClienteId { get; set; }
        public Usuario Cliente { get; set; }
    }
}
