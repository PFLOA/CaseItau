using System.Collections.Generic;
using A4S.CaseItau.Core.Models;

namespace A4S.CaseItau.Domain.Entidades
{   
    public class Raca : Entity<string>
    {
        public string Nome { get; set; }
        public string Temperamento { get; set; }
        public string Origem { get; set; }
        public string Descricao { get; set; }
        public virtual List<Imagem> Imagens { get; set; }

        public Raca() { }

        public Raca(string nome, string temperamento, string origem, string descricao, string id)
        {
            Id = id;
            Nome = nome;
            Temperamento = temperamento;
            Origem = origem;
            Descricao = descricao;
        }
    }
}
