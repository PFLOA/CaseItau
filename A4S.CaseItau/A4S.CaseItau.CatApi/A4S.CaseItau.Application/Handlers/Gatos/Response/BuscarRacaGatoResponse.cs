using A4S.CaseItau.Domain.Entidades;

namespace A4S.CaseItau.Application.Handlers.Gatos.Response
{
    public class BuscarRacaGatoResponse
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Temperamento { get; set; }
        public string Origem { get; set; }
        public string Descricao { get; set; }

        public BuscarRacaGatoResponse(Raca raca)
        {
            Id = raca.Id;
            Nome = raca.Nome;
            Temperamento = raca.Temperamento;
            Origem = raca.Origem;
            Descricao = raca.Descricao;
        }
    }
}
