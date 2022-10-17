using A4S.CaseItau.Domain.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace A4S.CaseItau.Application.Handlers.Postagens.Response
{
    public class BuscarPostagensPorIdiomaPaisResponse
    {
        public string Idioma { get; set; }
        public int Total { get; set; }

        public void PostagemGrupos(IEnumerable<Postagem> postag, string idioma)
        {
            Idioma = idioma;
            Total = postag.Count();
        }
    }
}
