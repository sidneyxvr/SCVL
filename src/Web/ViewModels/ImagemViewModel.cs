using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class ImagemViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Caminho { get; set; }

        public int AnuncioId { get; set; }
        public AnuncioViewModel Anuncio { get; set; }
    }
}
