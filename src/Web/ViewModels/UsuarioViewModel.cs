using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid Id{ get; set; }

        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; } = true;
        public IEnumerable<AnuncioViewModel> Anuncios { get; set; }
    }
}
