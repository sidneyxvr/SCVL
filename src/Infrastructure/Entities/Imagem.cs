namespace Infrastructure.Entities
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Caminho { get; set; }
        public int AnuncioId { get; set; }
        public Anuncio Anuncio { get; set; }
    }
}