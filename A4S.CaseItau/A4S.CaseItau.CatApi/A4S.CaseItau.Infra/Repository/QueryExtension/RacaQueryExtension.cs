using A4S.CaseItau.Domain.Entidades;
using System.Linq;

namespace A4S.CaseItau.Infra.Repository.QueryExtension
{
    public static class RacaQueryExtension
    {
        public static IQueryable<Raca> FiltrarPorTemperamento(this IQueryable<Raca> query, string temperamento)
        {
            if (!string.IsNullOrEmpty(temperamento)) return query.Where(r => r.Temperamento.Contains(temperamento));

            return query;
        }

        public static IQueryable<Raca> FiltrarPorOrigem(this IQueryable<Raca> query, string origem)
        {
            if (!string.IsNullOrEmpty(origem)) return query.Where(r => r.Origem.Contains(origem));

            return query;
        }
    }
}
