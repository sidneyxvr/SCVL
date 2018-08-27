using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class AnuncioViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Digite entre 1 e 100 carateres no título.")]
        [Display(Name = "Título")]
        [Required]
        public string Titulo { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Digite entre 1 e 100 carateres na descrição dos autores.")]
        [Required]
        public string Autores { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "Digite entre 1 e 30 carateres na editora.")]
        [Required]
        public string Editora { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Digite entre 1 e 100 carateres na descrição das categorias.")]
        [Required]
        public string Categoria { get; set; }

        [Range(0, 999)]
        [Required]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Range(0, 999)]
        [Required]
        [Display(Name = "Quantidade Disponível")]
        public int QuantidadeDisponivel { get; set; }

        [StringLength(100, ErrorMessage = "Digite até 200 carateres no título.")]
        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }
        public bool Ativo { get; set; } = true;
        public Guid UsuarioId { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public IEnumerable<ImagemViewModel> Imagens { get; set; }
        public IEnumerable<VendaViewModel> Vendas { get; set; }
    }
}
