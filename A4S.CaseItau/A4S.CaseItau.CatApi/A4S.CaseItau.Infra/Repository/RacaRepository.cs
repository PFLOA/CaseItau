using A4S.CaseItau.Infra.Repository.QueryExtension;
using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Domain.Interface;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using A4S.CaseItau.Domain.Filter;
using A4S.CaseItau.Core.Infra;
using A4S.CaseItau.Infra.Data;
using System.Threading.Tasks;
using System.Linq;

namespace A4S.CaseItau.Infra.Repository
{
    public class RacaRepository : Repository<Raca, CaseItauCatApiContext, string>, IRacaRepository
    {
        public RacaRepository(ILogger<Raca> logger, CaseItauCatApiContext dbContext) : base(logger, dbContext) { }

        public async Task<IQueryable<Raca>> BuscarRacasGatosPorFiltro(BuscarRacasGatosRequestFilter filter)
        {
            return await Task.FromResult(Set.FiltrarPorTemperamento(filter.Temperamento).FiltrarPorOrigem(filter.Origem));
        }

        public async Task SalvarEmMassa(List<Raca> gatos)
        {
            foreach (var item in gatos)
            {
                var raca = Set.Find(item.Id);

                if (raca == null)
                {
                    Set.Add(item);

                    await context.SaveChangesAsync();
                }
            }

        }
    }
}
