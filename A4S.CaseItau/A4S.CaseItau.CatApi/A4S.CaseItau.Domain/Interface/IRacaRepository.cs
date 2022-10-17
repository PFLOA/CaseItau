using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Core.Interfaces;
using System.Collections.Generic;
using A4S.CaseItau.Domain.Filter;
using System.Threading.Tasks;
using System.Linq;

namespace A4S.CaseItau.Domain.Interface
{
    public interface IRacaRepository : IRepository<Raca>
    {
        Task SalvarEmMassa(List<Raca> raca);
        Task<IQueryable<Raca>> BuscarRacasGatosPorFiltro(BuscarRacasGatosRequestFilter filter);
    }
}
