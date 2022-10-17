using A4S.CaseItau.Core.Models;
using System;

namespace A4S.CaseItau.Domain.Entidades
{
    public class Postagem : Entity<long>
    {
        public long IdAuthor { get; set; }
        public string Text { get; set; }
        public string Idioma { get; set; }
        public DateTime DataPostagem { get; set; }
        public Usuario Usuario { get; set; }

        public Postagem() { }
        public Postagem(long idTweet, long idAuthor, string text, DateTime dataPostagem, string lang)
        {
            Id = idTweet;
            IdAuthor = idAuthor;
            Text = text;
            DataPostagem = dataPostagem;
            Idioma = lang;
        }
    }
}
