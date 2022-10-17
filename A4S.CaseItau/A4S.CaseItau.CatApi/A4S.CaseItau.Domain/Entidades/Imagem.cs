using A4S.CaseItau.Core.Models;

namespace A4S.CaseItau.Domain.Entidades
{
    public class Imagem : Entity<long>
    {
        public string IdImage { get; set; }
        public string IdRaca { get; set; }
        public string Altura { get; set; }
        public string Largura { get; set; }
        public string Url { get; set; }
        public string Categoria { get; set; }
        public Raca Raca { get; set; }

        public Imagem() { }

        public Imagem(string idImage, string idRaca, string altura, string largura, string url)
        {
            IdImage = idImage;
            IdRaca = idRaca;
            Altura = altura;
            Largura = largura;
            Url = url;
        }

        public Imagem(string idImage, string idRaca, string altura, string largura, string url, string category)
        {
            IdImage = idImage;
            IdRaca = idRaca;
            Altura = altura;
            Largura = largura;
            Url = url;
            Categoria = category;
        }
    }
}
