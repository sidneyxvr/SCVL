using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class VendaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Horário")]
        public DateTime Horario { get; set; }
        public int Status { get; set; }

        [Required]
        [Display(Name = "Forma de Pagamento")]
        public int FormaPagamento { get; set; }

        public double Avaliacao { get; set; }
        public int AnuncioId { get; set; }
        public AnuncioViewModel Anuncio { get; set; }
        public Guid VendedorId { get; set; }
        public UsuarioViewModel Vendedor { get; set; }
        public Guid ClienteId { get; set; }
        public UsuarioViewModel Cliente { get; set; }
    }
}