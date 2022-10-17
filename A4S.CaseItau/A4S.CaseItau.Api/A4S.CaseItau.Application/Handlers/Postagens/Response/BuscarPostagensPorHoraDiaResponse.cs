using A4S.CaseItau.Domain.Entidades;
using System.Collections.Generic;

namespace A4S.CaseItau.Application.Handlers.Postagens.Response
{
    public class BuscarPostagensPorHoraDiaResponse
    {
        public string DataHora { get; set; }
        public int Total
        {
            get
            {
                return Postagem.Count;
            }
        }
        public List<Postagem> Postagem { get; set; } = new List<Postagem>();

        public void AdicionarPostagemGrupo(Postagem postag)
        {
            Postagem.Add(postag);
        }
    }
}
