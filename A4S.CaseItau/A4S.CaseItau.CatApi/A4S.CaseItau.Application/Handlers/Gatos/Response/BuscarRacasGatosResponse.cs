using A4S.CaseItau.Domain.Entidades;

namespace A4S.CaseItau.Application.Handlers.Gatos.Response
{
    public class BuscarRacasGatosResponse : BuscarRacaGatoResponse
    {
        public BuscarRacasGatosResponse(Raca raca) : base(raca) { }

        public static implicit operator BuscarRacasGatosResponse(Raca raca)
        {
            return new BuscarRacasGatosResponse(raca);
        }
    }
}
